﻿using System;
using RestSharp;
using RestSharp.Authenticators;

namespace VinculacionBackend
{
    public class MailManager
    {    
        public static IRestResponse SendSimpleMessage(string emailAdress, string message, string subject)
        {

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                    new HttpBasicAuthenticator("api",
                    "key-8tw489mxfegaqewx93in2xo449q5p3l0");
            var request = new RestRequest();
            request.AddParameter("domain",
                "app5dcaf6d377cc4ddcb696b827eabcb975.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "vinculacion@gmail.com");
            String email = emailAdress;
            request.AddParameter("to", email);
            request.AddParameter("subject", subject);
            request.AddParameter("text", message);
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}