using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;

namespace APITest
{
    public class Tests
    {
        [Test]
        public void PostRequest()
        {
            //Arrange
            var client = new RestClient("http://dummy.restapiexample.com/api/v1/create");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(new
            {
                name = "IndustryConnect1002",
                salary = "123",
                age = "23"
            });

            //Act
            var response = client.Execute(request);
            Console.WriteLine("response status is " + response.ResponseStatus);

            foreach (var header in response.Headers)
            {
                Console.WriteLine(header.Name + ":" + header.Value + "\n");
            }

            Console.WriteLine("status code is " + response.StatusCode + "\n");
            Console.WriteLine("byte " + response.RawBytes.ToString() + "\n");
            Console.WriteLine("content " + response.Content + "\n");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            if(!response.Content.Contains("error"))
            {
                var jObject = JObject.Parse(response.Content);
                string name = jObject.GetValue("name").ToString();
                Console.WriteLine("name is " + name);
                Assert.AreEqual("IndustryConnect1002", name, "correct name received in response");
            }
            else
            {
                Assert.Fail("error occured");
            }
        }

        [Test]
        public void GetRequest()
        {
            //Arrange
            var client = new RestClient("http://dummy.restapiexample.com/api/v1/employee/187653");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            //Act
            var response = client.Execute(request);
            Console.WriteLine("response status is " + response.ResponseStatus);

            foreach (var header in response.Headers)
            {
                Console.WriteLine(header.Name + ":" + header.Value + "\n");
            }

            Console.WriteLine("status code is " + response.StatusCode + "\n");
            Console.WriteLine("byte " + response.RawBytes.ToString() + "\n");
            Console.WriteLine("content " + response.Content + "\n");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            if (!response.Content.Contains("error"))
            {
                var jObject = JObject.Parse(response.Content);
                string name = jObject.GetValue("employee_name").ToString();
                string id_returned = jObject.GetValue("id").ToString();
                Console.WriteLine("name is " + name);
                Assert.AreEqual("IndustryConnect1002", name, "correct name received in response");
                Assert.AreEqual("187653", id_returned, "correct id returned");
            }
            else
            {
                Assert.Fail("error occured");
            }

        }

        [Test]
        public void PutRequest()
        {
            //Arrange
            var client = new RestClient("http://dummy.restapiexample.com/api/v1/update/187653");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(new
            {
                name = "IndustryConnect10022233",
                salary = "123",
                age = "23"
            });

            //Act
            var response = client.Execute(request);
            Console.WriteLine("response status is " + response.ResponseStatus);

            foreach (var header in response.Headers)
            {
                Console.WriteLine(header.Name + ":" + header.Value + "\n");
            }

            Console.WriteLine("status code is " + response.StatusCode + "\n");
            Console.WriteLine("byte " + response.RawBytes.ToString() + "\n");
            Console.WriteLine("content " + response.Content + "\n");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            if (!response.Content.Contains("error"))
            {
                var jObject = JObject.Parse(response.Content);
                string name = jObject.GetValue("name").ToString();
                Console.WriteLine("name is " + name);
                Assert.AreEqual("IndustryConnect10022233", name, "correct name received in response");
            }
            else
            {
                Assert.Fail("error occured");
            }
        }

        [Test]
        public void DeleteRequest()
        {
            //Arrange
            var client = new RestClient("http://dummy.restapiexample.com/api/v1/delete/187653");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            //Act
            var response = client.Execute(request);
            Console.WriteLine("response status is " + response.ResponseStatus);

            foreach (var header in response.Headers)
            {
                Console.WriteLine(header.Name + ":" + header.Value + "\n");
            }

            Console.WriteLine("status code is " + response.StatusCode + "\n");
            Console.WriteLine("byte " + response.RawBytes.ToString() + "\n");
            Console.WriteLine("content " + response.Content + "\n");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            if (response.Content.Contains("success"))
            {
                Assert.Pass("delete successfully");
            }
            else
            {
                Assert.Fail("error occured");
            }
        }
    }
}

