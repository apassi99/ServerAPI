﻿using HomeAutomationServer.Models;
using HomeAutomationServer.Services;
using System;
using HomeAutomationServer.Services;
using HomeAutomationServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;

// Space controller class

namespace HomeAutomationServerAPI.Controllers
{
    public class SpaceController : ApiController
    {
        private SpaceRepository spaceRepository = new SpaceRepository();

        // GET api/space/houseid/spaceid
        /// <summary>
        /// Gets the spaces information with the houseid and spaceid provided.
        /// </summary>
        /// <param name="houseid"></param>
        /// <param name="spaceid"></param>
        /// <returns>Returns a JObject of the spaces information found.</returns>
        [Route("api/space/{houseid}/{spaceid}")]
        public JObject Get(string houseid, string spaceid)                        // HTTP GET - gets devices in the space
        {
            return spaceRepository.GetSpace(houseid, spaceid);
        }

        /* PATCH api/Space/id, name, type, housename
        public HttpResponseMessage Patch(int id, string name = "", int type = -1, int houseId = -1)                      // HTTP PATCH - updates information about the space
        {
            Exception ex = spaceRepository.UpdateSpace(id, name, type, houseId);
            var response = Request.CreateErrorResponse(System.Net.HttpStatusCode.NotModified, ex);
            if (ex.Message == "updated")
                return Request.CreateResponse(System.Net.HttpStatusCode.OK);

            return response;
        }*/

        // POST api/space/houseid/spaceid
        /// <summary>
        /// Posts the space with the JObject information provided and with the specified houseid and spaceid.
        /// </summary>
        /// <param name="houseid"></param>
        /// <param name="spaceid"></param>
        /// <param name="model"></param>
        /// <returns>Returns the space information found via a JObject.</returns>
        [Route("api/space/{houseid}/{spaceid}")]
        public JObject Post(string houseid, string spaceid, [FromBody] JObject model)                  // HTTP POST - posts a new space
        {
            return spaceRepository.SaveSpace(houseid, spaceid, model);
        }

        // DELETE api/space/houseid/spaceid
        /// <summary>
        /// Deletes the space specified by the houseid and spaceid
        /// </summary>
        /// <param name="houseid"></param>
        /// <param name="spaceid"></param>
        /// <returns>Returns the space deleted via a JObject.</returns>
        [Route("api/space/{houseid}/{spaceid}")]
        public JObject Delete(string houseid, string spaceid)                // HTTP DELETE - deletes a space
        {
            return spaceRepository.DeleteSpace(houseid, spaceid);
        }
    }
}
