using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;
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

        // POST: api/TextConversion
        [HttpPost]
        [Route("Xml")]
        public async Task<string> Xml(string parameter)
        {
            var textToParse = await ReadRequestBody();

            return this.textParser.Parse(textToParse).ToXmlString();
        }

        [HttpPost]
        [Route("Csv")]
        public async Task<string> Csv(string parameter)
        {
            var textToParse = await ReadRequestBody();

            return this.textParser.Parse(textToParse).ToCsv();
        }

        private async Task<string> ReadRequestBody()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
            }


        }

    }
}
