using ngEdu.Data.Infrastructure;
using ngEdu.Data.Repositories;
using ngEdu.Entities;
using ngEdu.Services;
using ngEdu.Services.Utilities;
using ngEdu.Web.Infrastructure.Core;
using ngEdu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ngEdu.Web.Controllers
{
    [Authorize(Roles="Admin")]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiControllerBase
    {
        private readonly IMembershipService _membershipService;

        public AccountController(IMembershipService membershipService,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _membershipService = membershipService;
        }


        //public IHttpActionResult Get()
        //{
        //    return CreateIHttpResponse(() =>
        //    {
        //        IHttpActionResult response = null;
        //        if (ModelState.IsValid)
        //        {
        //            MembershipContext _userContext = _membershipService.ValidateUser(user.Username, user.Password);

        //            if (_userContext.User != null)
        //            {
        //                response = Ok(new { success = true });
        //                // request.CreateResponse(HttpStatusCode.OK, new { success = true });
        //            }
        //            else
        //            {
        //                response = Ok(new { success = false });
        //                //request.CreateResponse(HttpStatusCode.OK, new { success = false });
        //            }
        //        }
        //        else
        //            response = Ok(new { success = false });
        //                //request.CreateResponse(HttpStatusCode.OK, new { success = false });

        //        return response;
        //    });

        //}
        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]

        public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    MembershipContext _userContext = _membershipService.ValidateUser(user.Username, user.Password);

                    if (_userContext.User != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }
                else
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = false });

                return response;
            });
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request, RegistrationViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
                }
                else
                {
                    Entities.User _user = _membershipService.CreateUser(user.Username, user.Email, user.Password, new int[] { 1 });

                    if (_user != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }

                return response;
            });
        }
    }
}
