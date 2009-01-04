// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Topshelf.Insturmentation
{
    using System.Management.Instrumentation;
    using Configuration;
    using Microsoft.Practices.ServiceLocation;

    //http://blogs.microsoft.co.il/blogs/sasha/archive/tags/WMI/default.aspx
    [ManagementEntity(Singleton = true)]
    [ManagementQualifier("Description", Value = "Obtain processor information.")]
    public class BasicServiceInstrumentation
    {
        [ManagementBind]
        public BasicServiceInstrumentation()
        {
        }

        [ManagementProbe]
        [ManagementQualifier("Description", Value="Number of Services Hosted")]
        public int NumberOfServicesHosted
        {
            get
            {
                var count = 0;
                foreach(var x in ServiceLocator.Current.GetAllInstances<IService>())
                {
                    count++;
                }
                return count;
            }
        }
    }
}