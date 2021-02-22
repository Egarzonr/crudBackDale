using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrudAngular.Models;

namespace CrudAngular.Controllers
{
    [RoutePrefix("Api")]
    public class CRUDAPIController : ApiController
    {

        CrudAngularEntities objEntity = new CrudAngularEntities();


        // ******************* Clients *******************

        [HttpGet]
        [Route("AllClientDetails")]
        public IQueryable<ClientDetail> GetClient()
        {
            try
            {
                return objEntity.ClientDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetClientDetailsById/{clientId}")]
        public IHttpActionResult GetClientById(string clientId)
        {
            ClientDetail objCli = new ClientDetail();
            int ID = Convert.ToInt32(clientId);
            try
            {
                objCli = objEntity.ClientDetails.Find(ID);
                if (objCli == null)
                {

                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(objCli);
        }

        [HttpPost]
        [Route("InsertClientDetails")]
        public IHttpActionResult PostClient(ClientDetail data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                objEntity.ClientDetails.Add(data);
                objEntity.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateClientDetails")]
        public IHttpActionResult PutClient(ClientDetail client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ClientDetail objCli = new ClientDetail();
                objCli = objEntity.ClientDetails.Find(client.clientId);
                if(objCli != null)
                {
                    objCli.clientName = client.clientName;
                    objCli.clientSurname = client.clientSurname;
                    objCli.clientPhone = client.clientPhone;
                    objCli.clientNumber = client.clientNumber;
                }
                
                int i = this.objEntity.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(client);
        }


        [HttpDelete]
        [Route("DeleteClientDetails")]
        public IHttpActionResult DeleteClientDelete(int id)
        {
            ClientDetail client = objEntity.ClientDetails.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            objEntity.ClientDetails.Remove(client);
            objEntity.SaveChanges();
                   
            return Ok(client);
        }


        // ******************* Products ******************* 


        [HttpGet]
        [Route("AllProductDetails")]
        public IQueryable<ProductDetail> GetProduct()
        {
            try
            {
                return objEntity.ProductDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetProductDetailsById/{productId}")]
        public IHttpActionResult GetProductById(string productId)
        {
            ProductDetail objPro = new ProductDetail();
            int ID = Convert.ToInt32(productId);
            try
            {
                objPro = objEntity.ProductDetails.Find(ID);
                if (objPro == null)
                {

                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(objPro);
        }

        [HttpPost]
        [Route("InsertProductDetails")]
        public IHttpActionResult PostProduct(ProductDetail data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                objEntity.ProductDetails.Add(data);
                objEntity.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateProductDetails")]
        public IHttpActionResult PutProduct(ProductDetail product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ProductDetail objPro = new ProductDetail();
                objPro = objEntity.ProductDetails.Find(product.productId);
                if (objPro != null)
                {
                    objPro.productName = product.productName;
                    objPro.productUnitvalue = product.productUnitvalue;
                }

                int i = this.objEntity.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(product);
        }


        [HttpDelete]
        [Route("DeleteProductDetails")]
        public IHttpActionResult DeleteProductDelete(int id)
        {
            ProductDetail product = objEntity.ProductDetails.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            objEntity.ProductDetails.Remove(product);
            objEntity.SaveChanges();

            return Ok(product);
        }



        // ******************* Sales ******************* 

        [HttpGet]
        [Route("AllSaleDetails")]
        public IQueryable<SaleDetail> GetSale()
        {
            try
            {
                return objEntity.SaleDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetSaleDetailsById/{saleId}")]
        public IHttpActionResult GetSaleById(string saleId)
        {
            SaleDetail objSal = new SaleDetail();
            int ID = Convert.ToInt32(saleId);
            try
            {
                objSal = objEntity.SaleDetails.Find(ID);
                if (objSal == null)
                {

                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(objSal);
        }

        [HttpPost]
        [Route("InsertSaleDetails")]
        public IHttpActionResult PostSale(SaleDetail data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                objEntity.SaleDetails.Add(data);
                objEntity.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateSaleDetails")]
        public IHttpActionResult PutSale(SaleDetail sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                SaleDetail objSal = new SaleDetail();
                objSal = objEntity.SaleDetails.Find(sale.saleId);
                if (objSal != null)
                {
                    objSal.productName = sale.productName;
                    objSal.clientName = sale.clientName;
                    objSal.saleQuantity = sale.saleQuantity;
                    objSal.productUnitvalue = sale.productUnitvalue;
                    objSal.saleTotalvalue = sale.saleTotalvalue;

                }

                int i = this.objEntity.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(sale);
        }


        [HttpDelete]
        [Route("DeleteSaleDetails")]
        public IHttpActionResult DeleteSaleDelete(int id)
        {
            SaleDetail sale = objEntity.SaleDetails.Find(id);
            if (sale == null)
            {
                return NotFound();
            }

            objEntity.SaleDetails.Remove(sale);
            objEntity.SaveChanges();

            return Ok(sale);
        }











    }
}
