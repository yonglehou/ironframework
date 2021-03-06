﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RESTAPIWrapperClinet.cs" company="">
//   
// </copyright>
// <summary>
//   RESTAPIWrapperClinet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataServiceClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web;

    using System.Text;
    using IronFramework.Utility;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using System.Net.Http.Formatting;

    /// <summary>
    ///     RESTAPIWrapperClinet For DTO transfer with Front-end
    /// </summary>
    public class RESTAPIWrapperClinet : IRESTAPIWrapperClinet
    {
        #region Static Fields

        /// <summary>
        ///     The log
        /// </summary>
        private static readonly ILogger log = new Logger("RESTAPIWrapperClinet");

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RESTAPIWrapperClinet" /> class.
        /// </summary>
        public RESTAPIWrapperClinet()
        {
            this.URI = ServiceConfig.URI;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RESTAPIWrapperClinet"/> class.
        /// </summary>
        /// <param name="uRI">
        /// The u ri.
        /// </param>
        public RESTAPIWrapperClinet(string uRI)
        {
            this.URI = uRI;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the URI.
        /// </summary>
        /// <value>
        ///     The URI.
        /// </value>
        public string URI { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Instances this instance.
        /// </summary>
        /// <returns>
        /// The <see cref="RESTAPIWrapperClinet"/>.
        /// </returns>
        public static RESTAPIWrapperClinet Instance()
        {
            return new RESTAPIWrapperClinet();

            // return Message.Utility.Singleton.GetInstance<RESTAPIWrapperClinet>();
        }

        /// <summary>
        /// Instances the specified _u ri.
        /// </summary>
        /// <param name="_uRI">
        /// The _u ri.
        /// </param>
        /// <returns>
        /// The <see cref="RESTAPIWrapperClinet"/>.
        /// </returns>
        public static RESTAPIWrapperClinet Instance(string _uRI)
        {
            return new RESTAPIWrapperClinet(_uRI);
        }

        /// <summary>
        /// Clients the HTTP delete.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> ClientHTTPDelete<TResult>(int id)
        {
            return await ClientHTTPDelete<TResult>(id, null);
        }

        /// <summary>
        /// Clients the HTTP delete.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="customURL">The custom URL.</param>
        /// <returns></returns>
        public async Task<bool> ClientHTTPDelete<TResult>(int id, string customURL) 
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                string entityname = typeof(TResult).Name;
                entityname = entityname.Substring(0, entityname.IndexOf("Dto"));

                string routingUrl = string.Empty;

                if (string.IsNullOrEmpty(customURL))
                {
                    routingUrl = string.Format("api/{0}/{1}", entityname, id);
                }
                else
                {
                    routingUrl = string.Format("api/{0}/{1}/{2}", entityname, customURL, id);
                }

                routingUrl += "/?" + VerifyTransactionSN.GenerateRandomInt();

                HttpResponseMessage response = await client.DeleteAsync(routingUrl);

                log.DebugFormat("请求URL:{0}  结果:{1}", client.BaseAddress + routingUrl, response.IsSuccessStatusCode);

                if (!response.IsSuccessStatusCode)
                {
                    log.Error(response.Content.ReadAsStringAsync().Result);
                }

                return response.IsSuccessStatusCode;
            }
        }


        /// <summary>
        /// Clients the HTTP get.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <param name="id">
        /// The identifier.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<TResult> ClientHTTPGet<TResult>(int id) where TResult : new()
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                string entityname = typeof(TResult).Name;
                entityname = entityname.Substring(0, entityname.IndexOf("Dto"));
                string routingUrl = string.Format("api/{0}/{1}", entityname, id) + "/?"
                                    + VerifyTransactionSN.GenerateRandomInt();

                HttpResponseMessage response = await client.GetAsync(routingUrl);

                log.DebugFormat("请求URL:{0}  结果:{1}", client.BaseAddress + routingUrl, response.IsSuccessStatusCode);

                var results = new TResult();
                results = await ReadAsObject(response, results);
                return results;
            }
        }

        /// <summary>
        /// Clients the HTTP get.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of the result.
        /// </typeparam>
        /// <param name="id">
        /// The identifier.
        /// </param>
        /// <param name="customURL">
        /// The custom URL.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<TResult> ClientHTTPGet<TResult>(int id, string customURL) where TResult : new()
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                string entityname = typeof(TResult).Name;
                entityname = entityname.Substring(0, entityname.IndexOf("Dto"));

                string routingUrl = string.Empty;

                if (string.IsNullOrEmpty(customURL))
                {
                    routingUrl = string.Format("api/{0}/{1}", entityname, id);
                }
                else
                {
                    routingUrl = string.Format("api/{0}/{1}/{2}", entityname, customURL, id);
                }

                routingUrl += "/?" + VerifyTransactionSN.GenerateRandomInt();

                HttpResponseMessage response = await client.GetAsync(routingUrl);

                log.DebugFormat("请求URL:{0}  结果:{1}", client.BaseAddress + routingUrl, response.IsSuccessStatusCode);

                var results = new TResult();
                results = await ReadAsObject(response, results);
                return results;
            }
        }


        /// <summary>
        /// Clients the HTTP get string.
        /// </summary>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="paramstr">The paramstr.</param>
        /// <param name="customURL">The custom URL.</param>
        /// <param name="isawait">if set to <c>true</c> [isawait].</param>
        /// <returns></returns>
        public async Task<string> ClientHTTPGetString<Query>(string paramstr, string customURL, bool isawait) where Query : new()
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                string entityname = typeof(Query).Name;
                entityname = entityname.Substring(0, entityname.IndexOf("Dto"));

                string routingUrl = string.Empty;

                if (string.IsNullOrEmpty(customURL))
                {
                    routingUrl = string.Format("api/{0}/{1}", entityname, paramstr);
                }
                else
                {
                    routingUrl = string.Format("api/{0}/{1}?{2}", entityname, customURL, paramstr);
                }

                routingUrl += "&" + VerifyTransactionSN.GenerateRandomInt();

                HttpResponseMessage response = await client.GetAsync(routingUrl).ConfigureAwait(isawait);

                log.DebugFormat("请求URL:{0}  结果:{1}", client.BaseAddress + routingUrl, response.IsSuccessStatusCode);

                string results = string.Empty;
                if (response.IsSuccessStatusCode)
                {
                    results = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    log.Error(response.Content.ReadAsStringAsync().Result);
                }
                return results;
            }
        }

        /// <summary>
        /// Clients the HTTP get by URL.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <typeparam name="Query">
        /// The type of the uery.
        /// </typeparam>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="url">
        /// The URL.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<TResult> ClientHTTPGetList<TResult, Query>(Query query, string url) where TResult : new()
        {
            return await ClientHTTPGetList<TResult,Query>(query, url, true);
        }

        /// <summary>
        /// Clients the HTTP get by URL.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <typeparam name="Query">
        /// The type of the uery.
        /// </typeparam>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="url">
        /// The URL.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<TResult> ClientHTTPGetList<TResult, Query>(Query query, string url,bool isawait=true) where TResult : new()
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                string entityname = GetAPIControllerName<Query>();

                string querystring = this.GetQueryString(query);
                string routingUrl = string.Format("api/{0}/{1}?{2}", entityname, url, querystring) + "&random="
                                    + VerifyTransactionSN.GenerateRandomInt();

                HttpResponseMessage response = await client.GetAsync(routingUrl).ConfigureAwait(isawait);

                log.DebugFormat("请求URL:{0}  结果:{1}", client.BaseAddress + routingUrl, response.IsSuccessStatusCode);

                var results = new TResult();
                results = await ReadAsObject(response, results);
                return results;
            }
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <typeparam name="Query">
        /// The type of the uery.
        /// </typeparam>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<TResult> ClientHTTPGetList<TResult, Query>(Query query) where TResult : new()
        {
            return await this.ClientHTTPGetList<TResult, Query>(query, true);
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <typeparam name="Query">
        /// </typeparam>
        /// <param name="query">
        /// </param>
        /// <param name="isawait">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<TResult> ClientHTTPGetList<TResult, Query>(Query query, bool isawait) where TResult : new()
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                string entityname = GetAPIControllerName<Query>();

                string querystring = this.GetQueryString(query);
                string routingUrl = string.Format("api/{0}/?{1}", entityname, querystring) + "&random="
                                    + VerifyTransactionSN.GenerateRandomInt();

                // ?pageindex=1&pagesize=10
                HttpResponseMessage response = await client.GetAsync(routingUrl).ConfigureAwait(isawait);
                log.DebugFormat("请求URL:{0}  结果:{1}", client.BaseAddress + routingUrl, response.IsSuccessStatusCode);

                var results = new TResult();
                results = await ReadAsObject(response, results);
                return results;
            }
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of the result.
        /// </typeparam>
        /// <typeparam name="Query">
        /// The type of the uery.
        /// </typeparam>
        /// <param name="partialURI">
        /// The partial URI.
        /// </param>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="isawait">
        /// if set to <c>true</c> [isawait].
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<TResult> ClientHTTPGetList<TResult, Query>(string partialURI, Query query, bool isawait)
            where TResult : new()
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                string entityname = GetAPIControllerName<Query>();

                string querystring = this.GetQueryString(query);
                string routingUrl = string.Format("api/{0}/{1}/?{2}", entityname, partialURI, querystring) + "&random="
                                    + VerifyTransactionSN.GenerateRandomInt();

                // ?pageindex=1&pagesize=10
                HttpResponseMessage response = await client.GetAsync(routingUrl).ConfigureAwait(isawait);
                log.DebugFormat("请求URL:{0}  结果:{1}", client.BaseAddress + routingUrl, response.IsSuccessStatusCode);

                var results = new TResult();
                results = await ReadAsObject(response, results);
                return results;
            }
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TQueryDto">The type of the query dto.</typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="partialURI">The partial URI.</param>
        /// <param name="query">The query.</param>
        /// <param name="isawait">if set to <c>true</c> [isawait].</param>
        /// <returns></returns>
        public async Task<TResult> ClientHTTPGetList<TResult, TQueryDto, Query>(string partialURI, Query query, bool isawait)
where TResult : new()
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                string entityname = GetAPIControllerName<TQueryDto>();

                string querystring = this.GetQueryString(query);
                string routingUrl = string.Format("api/{0}/{1}/?{2}", entityname, partialURI, querystring) + "&random="
                                    + VerifyTransactionSN.GenerateRandomInt();

                // ?pageindex=1&pagesize=10
                HttpResponseMessage response = await client.GetAsync(routingUrl).ConfigureAwait(isawait);
                log.DebugFormat("请求URL:{0}  结果:{1}", client.BaseAddress + routingUrl, response.IsSuccessStatusCode);

                var results = new TResult();
                results = await ReadAsObject(response, results);
                return results;
            }
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of the result.
        /// </typeparam>
        /// <typeparam name="QueryDto">
        /// The type of the uery dto.
        /// </typeparam>
        /// <param name="queryString">
        /// The query string.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<TResult> ClientHTTPGetList<TResult, QueryDto>(string queryString) where TResult : new()
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                string entityname = GetAPIControllerName<QueryDto>();

                string querystring = queryString;
                string routingUrl = string.Format("api/{0}/?{1}", entityname, querystring) + "&random="
                                    + VerifyTransactionSN.GenerateRandomInt();

                // ?pageindex=1&pagesize=10
                HttpResponseMessage response = await client.GetAsync(routingUrl);
                log.DebugFormat("请求URL:{0}  结果:{1}", client.BaseAddress + routingUrl, response.IsSuccessStatusCode);

                var results = new TResult();
                results = await ReadAsObject(response, results);
                return results;
            }
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of the result.
        /// </typeparam>
        /// <typeparam name="QueryDto">
        /// The type of the uery dto.
        /// </typeparam>
        /// <param name="partialURI">
        /// The partial URI.
        /// </param>
        /// <param name="queryString">
        /// The query string.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<TResult> ClientHTTPGetList<TResult, QueryDto>(string partialURI, string queryString)
            where TResult : new()
        {
            return await this.ClientHTTPGetList<TResult, QueryDto>(partialURI, queryString, true);
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of the result.
        /// </typeparam>
        /// <typeparam name="QueryDto">
        /// The type of the uery dto.
        /// </typeparam>
        /// <param name="partialURI">
        /// The partial URI.
        /// </param>
        /// <param name="queryString">
        /// The query string.
        /// </param>
        /// <param name="configureAwait">
        /// if set to <c>true</c> [configure await].
        /// </param>
        /// <see cref="http://stackoverflow.com/questions/12933090/async-await-with-configureawaits-continueoncapturedcontext-parameter-and-synchr"/>
        /// <seealso cref="http://stackoverflow.com/questions/12482338/async-action-filter-in-mvc-4"/>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<TResult> ClientHTTPGetList<TResult, QueryDto>(
            string partialURI,
            string queryString,
            bool configureAwait) where TResult : new()
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                string entityname = GetAPIControllerName<QueryDto>();

                string querystring = queryString;
                string routingUrl = string.Format("api/{0}/{1}/?{2}", entityname, partialURI, querystring) + "&random="
                                    + VerifyTransactionSN.GenerateRandomInt();

                // ?pageindex=1&pagesize=10
                HttpResponseMessage response = await client.GetAsync(routingUrl).ConfigureAwait(configureAwait);
                log.DebugFormat("请求URL:{0}  结果:{1}", client.BaseAddress + routingUrl, response.IsSuccessStatusCode);

                var results = new TResult();
                results = await ReadAsObject(response, results);
                return results;
            }
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="partialURI">The partial URI.</param>
        /// <param name="isawait">if set to <c>true</c> [isawait].</param>
        /// <returns>ClientHTTPGetList</returns>
          public async Task<TResult> ClientHTTPGetList<TResult, Query>(string partialURI, bool isawait)
    where TResult : new()
        {
              return await ClientHTTPGetList<TResult, Query>(partialURI, isawait, true);
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="partialURI">The partial URI.</param>
        /// <param name="isawait">if set to <c>true</c> [isawait].</param>
        /// <returns></returns>
        public async Task<TResult> ClientHTTPGetList<TResult, Query>(string partialURI, bool isawait, bool enableRandomNumber)
    where TResult : new()
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                string entityname = GetAPIControllerName<Query>();

                string routingUrl = string.Format("api/{0}/{1}/?", entityname, partialURI);

                if (enableRandomNumber)
                {
                    routingUrl += VerifyTransactionSN.GenerateRandomInt();
                }
                  
                HttpResponseMessage response = await client.GetAsync(routingUrl).ConfigureAwait(isawait);
                log.DebugFormat("请求URL:{0}  结果:{1}", client.BaseAddress + routingUrl, response.IsSuccessStatusCode);

                var results = new TResult();
                results = await ReadAsObject(response, results);
                return results;
            }
        }

        /// <summary>
        /// Clients the HTTP put.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> ClientHTTPPut<TResult>(TResult model)
        {
            return await this.ClientHTTPPut(model, null);
        }

        /// <summary>
        /// Clients the HTTP put.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="customPartialUri">
        /// The custom partial URI.
        /// </param>
        /// <returns>
        /// bool
        /// </returns>
        public async Task<bool> ClientHTTPPut<TResult>(TResult model, string customPartialUri)
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                // HTTP PUT
                string entityname = typeof(TResult).Name;
                int dtoindex = entityname.IndexOf("Dto");

                if (dtoindex > 0)
                {
                    entityname = entityname.Substring(0, dtoindex);
                }

                string routingUrl = "api/" + entityname;

                if (!string.IsNullOrEmpty(customPartialUri))
                {
                    routingUrl += "/" + customPartialUri;
                }

                routingUrl += "?randmo=" + VerifyTransactionSN.GenerateRandomInt();
                HttpResponseMessage response = await client.PutAsJsonAsync(routingUrl, model);

                log.DebugFormat(
                    "请求URL:{0}  object {1}  结果:{2}",
                    client.BaseAddress + routingUrl,
                    model,
                    response.IsSuccessStatusCode);
                if (!response.IsSuccessStatusCode)
                {
                    log.Error(response.Content.ReadAsStringAsync().Result);
                }

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<TResult> ClientHTTPPut<TResult, TQueryDto, Query>(Query model, string customPartialUri) where TResult : new()
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                // HTTP PUT
                string entityname = typeof(TQueryDto).Name;
                int dtoindex = entityname.IndexOf("Dto");

                if (dtoindex > 0)
                {
                    entityname = entityname.Substring(0, dtoindex);
                }

                string routingUrl = "api/" + entityname;

                if (!string.IsNullOrEmpty(customPartialUri))
                {
                    routingUrl += "/" + customPartialUri;
                }

                routingUrl += "?randmo=" + VerifyTransactionSN.GenerateRandomInt();
                HttpResponseMessage response = await client.PutAsJsonAsync(routingUrl, model);

                log.DebugFormat(
                    "请求URL:{0}  object {1}  结果:{2}",
                    client.BaseAddress + routingUrl,
                    model,
                    response.IsSuccessStatusCode);
                if (!response.IsSuccessStatusCode)
                {
                    log.Error(response.Content.ReadAsStringAsync().Result);
                }

                var results = new TResult();
                results = await ReadAsObject(response, results);
                return results;
            }
        }


        public async Task<bool> ClientHTTPPut<TResult, Query>(Query model, string customPartialUri)
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                // HTTP PUT
                string entityname = typeof(TResult).Name;
                int dtoindex = entityname.IndexOf("Dto");

                if (dtoindex > 0)
                {
                    entityname = entityname.Substring(0, dtoindex);
                }

                string routingUrl = "api/" + entityname;

                if (!string.IsNullOrEmpty(customPartialUri))
                {
                    routingUrl += "/" + customPartialUri;
                }

                routingUrl += "?randmo=" + VerifyTransactionSN.GenerateRandomInt();
                HttpResponseMessage response = await client.PutAsJsonAsync(routingUrl, model);

                log.DebugFormat(
                    "请求URL:{0}  object {1}  结果:{2}",
                    client.BaseAddress + routingUrl,
                    model,
                    response.IsSuccessStatusCode);
                if (!response.IsSuccessStatusCode)
                {
                    log.Error(response.Content.ReadAsStringAsync().Result);
                }

                return response.IsSuccessStatusCode;
            }
        }

        /// <summary>
        /// Clients the invoke HTTP post.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> ClientHttpPOST<TResult>(TResult model)
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                // HTTP POST
                string entityname = typeof(TResult).Name;
                entityname = entityname.Substring(0, entityname.IndexOf("Dto"));
                string routingUrl = "api/" + entityname + "/?" + VerifyTransactionSN.GenerateRandomInt();

                HttpResponseMessage response = await client.PostAsJsonAsync(routingUrl, model);

                log.DebugFormat(
                    "请求URL:{0}  object {1}  结果:{2}",
                    client.BaseAddress + routingUrl,
                    model,
                    response.IsSuccessStatusCode);
                if (!response.IsSuccessStatusCode)
                {
                    log.Error(response.Content.ReadAsStringAsync().Result);
                }

                return response.IsSuccessStatusCode;
            }
        }






        #endregion

        #region Methods



        /// <summary>
        /// Gets the name of the API controller.
        /// </summary>
        /// <typeparam name="QueryDto">
        /// The type of the uery dto.
        /// </typeparam>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// You should pass a object which name end with 'DTO'
        /// </exception>
        private static string GetAPIControllerName<QueryDto>()
        {
            string entityname = string.Empty;
            if (typeof(QueryDto).IsGenericType)
            {
                entityname = typeof(QueryDto).GenericTypeArguments.FirstOrDefault().Name;
            }
            else
            {
                entityname=typeof(QueryDto).Name;
            }


            int pos = entityname.IndexOf("Dto");
            if (pos <= 0)
            {
                throw new ArgumentException("You should pass a object which name end with 'DTO'");
            }

            entityname = entityname.Substring(0, pos);
            return entityname;
        }

        /// <summary>
        /// Reads as object.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of the result.
        /// </typeparam>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <param name="results">
        /// The results.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private static async Task<TResult> ReadAsObject<TResult>(HttpResponseMessage response, TResult results)
            where TResult : new()
        {
            if (response.IsSuccessStatusCode)
            {

                //http://stackoverflow.com/questions/13915485/net-httpclient-with-custom-jsonconverter
                results = await response.Content.ReadAsAsync<TResult>(new[] {new JsonMediaTypeFormatter {
          SerializerSettings = new JsonSerializerSettings { 
              Converters = new List<JsonConverter> {
                //list of your converters
               }
             } 
          }
    });
            }
            else
            {
                log.Error(response.Content.ReadAsStringAsync().Result);
            }

            return results;
        }

        /// <summary>
        /// Creates the HTTP header.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        private void CreateHttpHeader(HttpClient client)
        {
            string webapiURI = this.URI;
            if (string.IsNullOrEmpty(webapiURI))
            {
                throw new ArgumentNullException("REST Service API should not be null");
            }

            client.BaseAddress = new Uri(webapiURI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //auth
            client.DefaultRequestHeaders.Add("X-MonsterAppApiKey", string.Format("{0}:{1}", SecurityConfig.UserID, SecurityConfig.Password));
        }

        /// <summary>
        /// Gets the query string.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetQueryString(object obj)
        {
            if (obj != null)
            {
                IEnumerable<string> properties = from p in obj.GetType().GetProperties()
                                                 where
                                                     p.GetValue(obj, null) != null
                                                     && p.CustomAttributes.All(
                                                         attc => attc.AttributeType != typeof(KeyAttribute))
                                                 select
                                                     p.Name + "="
                                                     + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

                return string.Join("&", properties.ToArray());
            }
            return string.Empty;
        }

        #endregion


        public async Task<bool> ClientHttpPOST<T, Query>(Query query, string customURL) where T : new()
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                // HTTP PUT
                string entityname = typeof(T).Name;
                int dtoindex = entityname.IndexOf("Dto");

                if (dtoindex > 0)
                {
                    entityname = entityname.Substring(0, dtoindex);
                }

                string routingUrl = "api/" + entityname;

                if (!string.IsNullOrEmpty(customURL))
                {
                    routingUrl += "/" + customURL;
                }

                routingUrl += "?randmo=" + VerifyTransactionSN.GenerateRandomInt();
                HttpResponseMessage response = await client.PutAsJsonAsync(routingUrl, query);

                log.DebugFormat(
                    "请求URL:{0}  object {1}  结果:{2}",
                    client.BaseAddress + routingUrl,
                    query,
                    response.IsSuccessStatusCode);
                if (!response.IsSuccessStatusCode)
                {
                    log.Error(response.Content.ReadAsStringAsync().Result);
                }

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> ClientHttpPOST<T, Query>(Query query, string customURL, bool isawait) where T : new()
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                // HTTP PUT
                string entityname = typeof(T).Name;
                int dtoindex = entityname.IndexOf("Dto");

                if (dtoindex > 0)
                {
                    entityname = entityname.Substring(0, dtoindex);
                }

                string routingUrl = "api/" + entityname;

                if (!string.IsNullOrEmpty(customURL))
                {
                    routingUrl += "/" + customURL;
                }

                routingUrl += "?randmo=" + VerifyTransactionSN.GenerateRandomInt();
                HttpResponseMessage response = await client.PutAsJsonAsync(routingUrl, query).ConfigureAwait(isawait);

                log.DebugFormat(
                    "请求URL:{0}  object {1}  结果:{2}",
                    client.BaseAddress + routingUrl,
                    query,
                    response.IsSuccessStatusCode);
                if (!response.IsSuccessStatusCode)
                {
                    log.Error(response.Content.ReadAsStringAsync().Result);
                }

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<ReturnObject> ClientHttpPOST<ReturnObject, T, Query>(Query query, string customURL)
            where ReturnObject : new()
            where T : new()
        {
            using (var client = new HttpClient())
            {
                this.CreateHttpHeader(client);

                // HTTP PUT
                string entityname = typeof(T).Name;
                int dtoindex = entityname.IndexOf("Dto");

                if (dtoindex > 0)
                {
                    entityname = entityname.Substring(0, dtoindex);
                }

                string routingUrl = "api/" + entityname;

                if (!string.IsNullOrEmpty(customURL))
                {
                    routingUrl += "/" + customURL;
                }

                routingUrl += "?randmo=" + VerifyTransactionSN.GenerateRandomInt();
                HttpResponseMessage response = await client.PutAsJsonAsync(routingUrl, query);

                var results = new ReturnObject();
                results = await ReadAsObject(response, results);
                return results;
            }
        }

     
    }
}