using Microsoft.AspNetCore.Mvc;
using solarLab_tt.Models;
using solarLab_tt.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace solarLab_tt.Controllers
{
    public class ServiceController : ApiController
    {
        [HttpPost, DisableRequestSizeLimit]
        [Route(nameof(Upload))]
        public ActionResult Upload()
        {
            var file = Request.Form.Files[0];
            var folderName = Path.Combine("wwwroot", "img");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine("http://", Request.Host.Value, "img", fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return Ok(new ImagePathResponse { Path = dbPath });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
