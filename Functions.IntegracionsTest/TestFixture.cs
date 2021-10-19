using Function_Integrationes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Functions.IntegracionsTest
{
    public class TestFixture : IDisposable

    {
        private Process process;
        public int port = 7071;
        public HttpClient Client = new HttpClient();
       

        public TestFixture() 
        {
            string dotnet = Environment.ExpandEnvironmentVariables(ConfigHelper.Settings.DotnetExecutablePath);
            string funtionHost = Environment.ExpandEnvironmentVariables(ConfigHelper.Settings.FunctionHostPath);
            string functionApp = Path.GetRelativePath(Directory.GetCurrentDirectory(), ConfigHelper.Settings.FunctionApplicationPath);
            process = new Process
            {
                StartInfo =
                {
                    FileName = dotnet,
                    Arguments = $"\"{funtionHost}\" start -p {port}",
                    WorkingDirectory = functionApp
                }
            };
            var success = process.Start();
            Client.BaseAddress = new Uri($"http://localhost:{port}");

        }

        public void Dispose()
        {
            if (!process.HasExited)
            {
                process.Kill();
            }
            process.Dispose();
        }
    }
}
