﻿// This code requires the Nuget package Microsoft.AspNet.WebApi.Client to be installed.
// Instructions for doing this in Visual Studio:
// Tools -> Nuget Package Manager -> Package Manager Console
// Install-Package Microsoft.AspNet.WebApi.Client

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CallRequestResponseService
{
    class Program
    {
        static void Main(string[] args)
        {
            InvokeRequestResponseService().Wait();
        }

        static async Task InvokeRequestResponseService()
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, List<Dictionary<string, string>>>() {
                        {
                            "input1",
                            new List<Dictionary<string, string>>(){new Dictionary<string, string>(){
                                            {
                                                "Col1", "A11"
                                            },
                                            {
                                                "Col2", "6"
                                            },
                                            {
                                                "Col3", "A34"
                                            },
                                            {
                                                "Col4", "A43"
                                            },
                                            {
                                                "Col5", "1169"
                                            },
                                            {
                                                "Col6", "A65"
                                            },
                                            {
                                                "Col7", "A75"
                                            },
                                            {
                                                "Col8", "4"
                                            },
                                            {
                                                "Col9", "A93"
                                            },
                                            {
                                                "Col10", "A101"
                                            },
                                            {
                                                "Col11", "4"
                                            },
                                            {
                                                "Col12", "A121"
                                            },
                                            {
                                                "Col13", "67"
                                            },
                                            {
                                                "Col14", "A143"
                                            },
                                            {
                                                "Col15", "A152"
                                            },
                                            {
                                                "Col16", "2"
                                            },
                                            {
                                                "Col17", "A173"
                                            },
                                            {
                                                "Col18", "1"
                                            },
                                            {
                                                "Col19", "A192"
                                            },
                                            {
                                                "Col20", "A201"
                                            },
                                            {
                                                "Col21", "1"
                                            },
                                }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };

                const string apiKey = "HvYoBjez5h+FvfPjI0H/MnSUlAqWFLm2zzzL9VH3ckBo/nnp8yhn7cOg8lbPyALNYhqMGJ+YbwmLB6WMTHjMgg=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/2bcc42d0cd844d85adb34fa5b652dad9/services/ea793e41b4e248189f02fa4f15709554/execute?api-version=2.0&format=swagger");

                // WARNING: The 'await' statement below can result in a deadlock
                // if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false)
                // so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)

                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("Result: {0}", result);
                }
                else
                {
                    Debug.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp,
                    // which are useful for debugging the failure
                    Debug.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(responseContent);
                }
            }
        }
    }
}