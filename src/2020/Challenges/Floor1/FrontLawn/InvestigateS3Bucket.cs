using Microsoft.Extensions.Logging;
using System.IO;
using System.Net;

namespace Janda.CTF.SANS.HolidayHack
{
    [Challenge(Type = "Objective", Number = 2, Name = "Investigate S3 Bucket", Flag = "North Pole: The Frostiest Place on Earth")]
    public class InvestigateS3Bucket : IChallenge
    {
        private readonly ILogger<InvestigateS3Bucket> _logger;       

        public InvestigateS3Bucket(ILogger<InvestigateS3Bucket> logger)
        {
            _logger = logger;
        }


        public void About()
        {
            @"
                
                When you unwrap the over-wrapped file, what text string is inside the package? 
                Talk to Shinny Upatree in front of the castle for hints on this challenge.

            ".Blog(_logger, "About");
        }

        public void Talks()
        {
            @"
                
                Spencer Gietzen, IOMs vs. IOAs in AWS | KringleCon 2020
                https://www.youtube.com/watch?v=KliCQbJT6YQ


            ".Blog(_logger, "Talks");
        }

        

        public void Run()
        {
            var client = new WebClient();

            _logger.LogInformation(client.DownloadString("http://s3.amazonaws.com/wrapper3000"));

            using Stream data = client.OpenRead($"http://s3.amazonaws.com/wrapper3000/package");
            using StreamReader reader = new StreamReader(data);
            var response = reader.ReadToEnd();
            _logger.LogInformation(response);

            data.Close();
            reader.Close();
        }
    }
}

