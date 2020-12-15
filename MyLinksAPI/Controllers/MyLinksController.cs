using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using MyLinksAPI.Data;
using MyLinksAPI.Services;
using MyLinksAPI.Models;
using AutoMapper;
using MyLinksAPI.DTOs;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyLinksAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class MyLinksController : ControllerBase
    {
        private readonly IMyLinksService _myLinksService;
        private readonly IMapper _mapper;

        public MyLinksController(IMyLinksService myLinksService, IMapper mapper)
        {
            _myLinksService = myLinksService;
            _mapper = mapper;
        }
        // GET: api/<MyLinksController>
        [HttpGet]
        public ActionResult<IEnumerable<MyLinkReadDTO>> Get()
        {
            var myLinks = _myLinksService.GetMyLinks();
            return Ok(_mapper.Map<IEnumerable<MyLinkReadDTO>>(myLinks));
        }

        // GET api/<MyLinksController>/5
        [HttpGet("{id}", Name = "GetMyLinkById")]
        public ActionResult<MyLinkReadDTO> GetMyLinkById(int id, string stsUserId)
        {
            var myLink = _myLinksService.GetMyLink(id, stsUserId);
            if(myLink == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<MyLinkReadDTO>(myLink));
        }

        //POST api/<MyLinksController>
        [HttpPost]
        [Route("Create")]
        public async Task<string> ReadStringDataManual()
        {
            
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string s = await reader.ReadToEndAsync();
                System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;
                byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(s);

                string s_unicode2 = System.Text.Encoding.UTF8.GetString(utf8Bytes);

                var myLink = JsonSerializer.Deserialize<MyLink>(s_unicode2);
                return s;
            }
        }

        [HttpPost]
        [EnableCors("MyPolicy")]
        public ActionResult<MyLinkReadDTO> CreateMyLink(MyLinkCreateDTO myLinkCreateDTO)
        {
            var myLinkModel = _mapper.Map<MyLink>(myLinkCreateDTO);
            try
            {
                _myLinksService.CreateMyLink(myLinkModel, myLinkCreateDTO.NameId);
            }
            catch(NullReferenceException ex)
            {
                return NotFound();
            }

            var result = _myLinksService.SaveChanges();

            var myLinkReadDTO = _mapper.Map<MyLinkReadDTO>(myLinkModel);
            return CreatedAtRoute(nameof(GetMyLinkById), new { id = myLinkReadDTO.MyLinkId }, myLinkReadDTO);
            //return Ok(myLinkReadDTO);
        }

        // PUT api/<MyLinksController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, MyLinkUpdateDTO myLinkUpdateDTO)
        {
            var myLinkModelFromRepo = _myLinksService.GetMyLink(id);
            if (myLinkUpdateDTO == null) return NotFound();

            _mapper.Map(myLinkUpdateDTO, myLinkModelFromRepo);
            _myLinksService.UpdateMyLink(myLinkModelFromRepo);
            _myLinksService.SaveChanges();

            return NoContent();
        }

        // DELETE api/<MyLinksController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var myLink = _myLinksService.GetMyLink(id);
            if (myLink == null) return NotFound();

            _myLinksService.DeleteMyLink(myLink);
            var result = _myLinksService.SaveChanges();
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
    }
}
