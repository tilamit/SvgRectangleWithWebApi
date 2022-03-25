using DrawRectangleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DrawRectangleApp.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] Shape aShape)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        //Get rectangle perimeters from jSon file
        [Route("api/values/GetValues")]
        [HttpGet]
        public Shape GetValues()
        {
            var jsonText = File.ReadAllText(@"D:\jSonData\jSonData.json");
            var data = JsonConvert.DeserializeObject<Shape>(jsonText);

            return data;
        }

        //Update rectangle perimeters in jSon file
        [Route("api/values/UpdateValue")]
        [HttpPost]
        public bool UpdateValue([FromBody] Shape aShape)
        {
            string json = File.ReadAllText(@"D:\jSonData\jSonData.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            jsonObj["x"] = aShape.x;
            jsonObj["y"] = aShape.y;
            jsonObj["w"] = aShape.w;
            jsonObj["h"] = aShape.h;

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"D:\jSonData\jSonData.json", output);

            return true;
        }
    }
}
