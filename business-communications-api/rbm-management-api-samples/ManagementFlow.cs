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
using System.Collections.Generic;
using System.IO;

using Google.Apis.BusinessCommunications.v1.Data;

namespace com.google.rbm.samples
{
    internal class ManagementFlow
    {
        private RbmApiOperations api;

        public ManagementFlow() {
            api = new RbmApiOperations();
        }

        protected Dictionary<string, string> ParseFlags(string[] args) {
            Dictionary<string, string> parsedFlags = new Dictionary<string, string>();

            foreach (string arg in args) {
                string a = arg.Trim();
                if (string.IsNullOrEmpty(a)) {
                    continue;
                }
                string[] pair = a.Split('=');
                if (pair.Length >= 2) {
                    parsedFlags.Add(pair[0].Trim(), pair[1].Trim());
                }
            }

            return parsedFlags;
        }

        public void Run(string[] args) {
            Dictionary<string, string> flags = ParseFlags(args);

            if (flags.ContainsKey("add_test_device")) {
                string msisdn = flags["msisdn"];
                string agentId = flags["agent_id"];

                Tester t = api.CreateTester(agentId, msisdn);
                Console.WriteLine("New tester identifier: " + t.Name);
                return;
            }

            if (flags.ContainsKey("get_tester")) {
                string testerId = flags["tester_id"];
                string agentId = flags["agent_id"];

                Tester t = api.GetTester(agentId, testerId);
                Console.WriteLine("Tester invite status: " + t.InviteStatus);
                return;
            }

            if (flags.ContainsKey("delete_tester")) {
                string testerId = flags["tester_id"];
                string agentId = flags["agent_id"];

                api.DeleteTester(agentId, testerId);
                Console.WriteLine("Tester deleted");
                return;
            }

            if (flags.ContainsKey("list_testers")) {
                string agentId = flags["agent_id"];

                System.Collections.Generic.IList<Tester> testers = api.ListTesters(agentId);

                foreach (Tester tester in testers) {
                    Console.WriteLine(tester.Name);
                }
                return;
            }
            if (flags.ContainsKey("upload_verification_document")) {
                string agentId = flags["agent_id"];
                string pdfPath = flags["pdf_path"];
                string source = flags.ContainsKey("attachment_source") ? flags["attachment_source"] : "VERIFICATION_PAGE";

                if (string.IsNullOrEmpty(pdfPath)) {
                    Console.WriteLine("Error: pdf_path parameter is required");
                    return;
                }

                Console.WriteLine("Uploading verification document from path: " + pdfPath);
                GoogleCommunicationsBusinesscommunicationsV1Attachment attachment = api.UploadVerificationDocument(agentId, pdfPath, source);
                Console.WriteLine("Upload success! Created attachment details:");
                Console.WriteLine("Name: " + attachment.Name);
                Console.WriteLine("GcsUrl: " + attachment.GcsUrl);
                Console.WriteLine("ContentType: " + attachment.ContentType);
                Console.WriteLine("SizeBytes: " + attachment.SizeBytes);
                return;
            }
        }

        static void Main(string[] args) {
            new ManagementFlow().Run(args);
        }
    }
}