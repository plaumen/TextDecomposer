using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TextDecomposer.Utils.Conversion;
using TextDecomposer.Utils.Parsing;

namespace TextDecomposer.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextConversionController : ControllerBase
    {
        private readonly ITextParser textParser;

        public TextConversionController(ITextParser textParser)
        {
            this.textParser = textParser;
        }

        [HttpGet]
        public ActionResult<string> Xml(string text)
        {
            return this.textParser.Parse(text).ToXmlString();
        }

        [HttpGet]
        public ActionResult<string> Csv(string text)
        {
            return this.textParser.Parse(text).ToXmlString();
        }

        // GET: api/TextConversion
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TextConversion/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TextConversion
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/TextConversion/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
