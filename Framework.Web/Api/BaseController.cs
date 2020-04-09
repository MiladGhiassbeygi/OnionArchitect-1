﻿using Framework.Web.Helpers;
using Microsoft.AspNetCore.Mvc;


namespace Framework.Web.Api
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly PagingMetadataHelper pagingMetadataHelper;

        public BaseController(PagingMetadataHelper pagingMetadataHelper)
        {
            this.pagingMetadataHelper = pagingMetadataHelper;
        }

        
    }
}

