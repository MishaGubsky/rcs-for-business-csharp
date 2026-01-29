/*
Copyright 2025 Google Inc. All rights reserved.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.IO;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.BusinessCommunications.v1;
using Google.Apis.BusinessCommunications.v1.Data;

namespace com.google.rbm.samples
{

    internal class RbmApiOperations {

        private const string BUSCOMMS_API_URL = "https://www.googleapis.com/auth/businesscommunications";
        
        private const string credentialsFileLocation = "./rbm-developer-service-account-credentials.json";
       
        private BusinessCommunicationsService businessCommunicationsService;

        private void InitCredentials(string credentialsFileLocation)
        {
            string[] scopes = new string[] { BUSCOMMS_API_URL };

            GoogleCredential credential;
            using (var stream = new FileStream(credentialsFileLocation,
                                               FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                                             .CreateScoped(scopes);
            }

            businessCommunicationsService = new BusinessCommunicationsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });
        }

        public RbmApiOperations() {
            Console.WriteLine("Initializing management helper");
            InitCredentials(credentialsFileLocation);
        }

        // Tester operations /////////////////////////////////////////////////

        public Tester CreateTester(string agentId, string testMsisdn) {
            Tester t = new Tester();

            t.AgentId = agentId;
            t.PhoneNumber = testMsisdn;

            Tester res = null;

            try {
                res = businessCommunicationsService.Testers.Create(t).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return res;
        }

        public Tester GetTester(string agentId, string testerId) {
            Tester t = new Tester();

            t.AgentId = agentId;
            t.Name = testerId;

            Tester res = null;

            try {
                TestersResource.GetRequest req =  businessCommunicationsService.Testers.Get(testerId);
                
                req.AgentId = agentId;
                res = req.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return res;
        }

        public void DeleteTester(string agentId, string testerId) {
            try {
                TestersResource.DeleteRequest req =  businessCommunicationsService.Testers.Delete(testerId);
                
                req.AgentId = agentId;
                req.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return;
        }

        public System.Collections.Generic.IList<Tester> ListTesters(string agentId) {
            System.Collections.Generic.IList<Tester> res = null;

            try {
                TestersResource.ListRequest req =  businessCommunicationsService.Testers.List();

                req.AgentId = agentId;
                res = req.Execute().Testers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return res;
        }
    }
}