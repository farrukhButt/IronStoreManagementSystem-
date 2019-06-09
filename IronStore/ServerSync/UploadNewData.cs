using AutoMapper;
using IronStore.Entity;
using IronStore.ServerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronStore.ServerSync
{
    class UploadNewData
    {
        public void UploadNewCustomers()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newCustomers = dbLocal.Customers.Where(aa => aa.StatusCode == (int)LocalDBStatusCode.Added).ToList();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Entity.Customer, ServerEntity.CustomerServer>());
            var mapper = config.CreateMapper();
            var customerserver = mapper.Map<List<Entity.Customer>, List<ServerEntity.CustomerServer>>(newCustomers);

            customerserver.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Added_From_Shop);

            newCustomers.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_On_Server);
            
            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();


                dbServer.CustomerServers.AddRange(customerserver);
                dbServer.SaveChanges();
                dbLocal.SaveChanges();


                localDBTransaction.Commit();
                ServerDBTransaction.Commit();
            }
            catch
            {
                throw;
            }
        }

        public void UploadNewItems()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newItemsLocal = dbLocal.Items.Where(aa => aa.StatusCode == (int) LocalDBStatusCode.Added).ToList();

            if (newItemsLocal.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Entity.Item, ServerEntity.ItemServer>());
            var mapper = config.CreateMapper();
            var itemsServer = mapper.Map<List<Entity.Item>, List<ServerEntity.ItemServer>>(newItemsLocal);


            newItemsLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_On_Server);

            itemsServer.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Added_From_Shop);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();


                dbServer.ItemServers.AddRange(itemsServer);
                dbServer.SaveChanges();
                dbLocal.SaveChanges();


                localDBTransaction.Commit();
                ServerDBTransaction.Commit();
            }
            catch
            {
                throw;
            }

        }


        public void UploadNewOrders()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newOrdersLocal = dbLocal.Orders.Where(aa => aa.StatusCode == (int)LocalDBStatusCode.Added).ToList();

            if (newOrdersLocal.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Entity.Order, ServerEntity.OrderServer>());
            var mapper = config.CreateMapper();
            var ordersServer = mapper.Map<List<Entity.Order>, List<ServerEntity.OrderServer>>(newOrdersLocal);


            newOrdersLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_On_Server);

            ordersServer.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Added_From_Shop);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();


                dbServer.OrderServers.AddRange(ordersServer);
                dbServer.SaveChanges();
                dbLocal.SaveChanges();


                localDBTransaction.Commit();
                ServerDBTransaction.Commit();
            }
            catch
            {
                throw;
            }
        }

        public void UploadNewOrderLines()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newOrderLinesLocal = dbLocal.OrderLines.Where(aa => aa.StatusCode == (int)LocalDBStatusCode.Added).ToList();

            if (newOrderLinesLocal.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Entity.OrderLine, ServerEntity.OrderLineServer>());
            var mapper = config.CreateMapper();
            var orderLinesServer = mapper.Map<List<Entity.OrderLine>, List<ServerEntity.OrderLineServer>>(newOrderLinesLocal);


            newOrderLinesLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_On_Server);

            orderLinesServer.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Added_From_Shop);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();


                dbServer.OrderLineServers.AddRange(orderLinesServer);
                dbServer.SaveChanges();
                dbLocal.SaveChanges();


                localDBTransaction.Commit();
                ServerDBTransaction.Commit();
            }
            catch
            {
                throw;
            }
        }

        public void UploadNewOrderPayments()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newOrderPaymentsLocal = dbLocal.OrderPaymentMades.Where(aa => aa.StatusCode == (int)LocalDBStatusCode.Added).ToList();

            if (newOrderPaymentsLocal.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Entity.OrderPaymentMade, ServerEntity.OrderPaymentMadeServer>());
            var mapper = config.CreateMapper();
            var orderPaymentsServer = mapper.Map<List<Entity.OrderPaymentMade>, List<ServerEntity.OrderPaymentMadeServer>>(newOrderPaymentsLocal);


            newOrderPaymentsLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_On_Server);

            orderPaymentsServer.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Added_From_Shop);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();


                dbServer.OrderPaymentMadeServers.AddRange(orderPaymentsServer);
                dbServer.SaveChanges();
                dbLocal.SaveChanges();


                localDBTransaction.Commit();
                ServerDBTransaction.Commit();
            }
            catch
            {
                throw;
            }

        }

        public void UploadSuppliers()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newSuppliersLocal = dbLocal.Suppliers.Where(aa => aa.StatusCode == (int)LocalDBStatusCode.Added).ToList();

            if (newSuppliersLocal.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Entity.Supplier, ServerEntity.SupplierServer>());
            var mapper = config.CreateMapper();
            var suppliersServer = mapper.Map<List<Entity.Supplier>, List<ServerEntity.SupplierServer>>(newSuppliersLocal);


            newSuppliersLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_On_Server);

            suppliersServer.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Added_From_Shop);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();


                dbServer.SupplierServers.AddRange(suppliersServer);
                dbServer.SaveChanges();
                dbLocal.SaveChanges();


                localDBTransaction.Commit();
                ServerDBTransaction.Commit();
            }
            catch
            {
                throw;
            }
        }


        public void UploadSupplierBankDetail()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newSupplierBanksLocal = dbLocal.SupplierBankDetails.Where(aa => aa.StatusCode == (int)LocalDBStatusCode.Added).ToList();

            if (newSupplierBanksLocal.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Entity.SupplierBankDetail, ServerEntity.SupplierBankDetailServer>());
            var mapper = config.CreateMapper();
            var supplierBanksServer = mapper.Map<List<Entity.SupplierBankDetail>, List<ServerEntity.SupplierBankDetailServer>>(newSupplierBanksLocal);


            newSupplierBanksLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_On_Server);

            supplierBanksServer.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Added_From_Shop);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();


                dbServer.SupplierBankDetailServers.AddRange(supplierBanksServer);
                dbServer.SaveChanges();
                dbLocal.SaveChanges();


                localDBTransaction.Commit();
                ServerDBTransaction.Commit();
            }
            catch
            {
                throw;
            }
        }


        public void UploadSupplierDuePayment()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newSupplierDuePaymentsLocal = dbLocal.SupplierDuePayments.Where(aa => aa.StatusCode == (int)LocalDBStatusCode.Added).ToList();

            if (newSupplierDuePaymentsLocal.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Entity.SupplierDuePayment, ServerEntity.SupplierDuePaymentsServer>());
            var mapper = config.CreateMapper();
            var supplierDuePaymentsServer = mapper.Map<List<Entity.SupplierDuePayment>, List<ServerEntity.SupplierDuePaymentsServer>>(newSupplierDuePaymentsLocal);


            newSupplierDuePaymentsLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_On_Server);

            supplierDuePaymentsServer.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Added_From_Shop);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();


                dbServer.SupplierDuePaymentsServers.AddRange(supplierDuePaymentsServer);
                dbServer.SaveChanges();
                dbLocal.SaveChanges();


                localDBTransaction.Commit();
                ServerDBTransaction.Commit();
            }
            catch
            {
                throw;
            }
        }


        public void UploadSupplierPaymentMade()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newSupplierPaymentsMadeLocal = dbLocal.SupplierPaymentMades.Where(aa => aa.StatusCode == (int)LocalDBStatusCode.Added).ToList();

            if (newSupplierPaymentsMadeLocal.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Entity.SupplierPaymentMade, ServerEntity.SupplierPaymentMadeServer>());
            var mapper = config.CreateMapper();
            var supplierPaymentsMadeServer = mapper.Map<List<Entity.SupplierPaymentMade>, List<ServerEntity.SupplierPaymentMadeServer>>(newSupplierPaymentsMadeLocal);


            newSupplierPaymentsMadeLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_On_Server);

            supplierPaymentsMadeServer.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Added_From_Shop);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();


                dbServer.SupplierPaymentMadeServers.AddRange(supplierPaymentsMadeServer);
                dbServer.SaveChanges();
                dbLocal.SaveChanges();


                localDBTransaction.Commit();
                ServerDBTransaction.Commit();
            }
            catch
            {
                throw;
            }
        }

        //public void UploadOrderReturn()
        //{

        //    FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
        //    FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
        //    var ordersUpdateLocal = dbLocal.OrderLines.Where(aa => aa.StatusCode == (int)LocalDBStatusCode.Updated).ToList();
        //    var orderPaymentsUpdatedLocal = dbLocal.OrderPaymentMades.Where(aa => aa.StatusCode == (int)LocalDBStatusCode.Updated).ToList();

        //    if (ordersUpdateLocal.Count == 0 && orderPaymentsUpdatedLocal.Count == 0)
        //    {
        //        return;
                
        //    }

        //    List<OrderPaymentMadeServer> OrderPaymentsUpdateServer = new List<OrderPaymentMadeServer>();

        //    if (orderPaymentsUpdatedLocal.Count != 0)
        //    {

        //        var config = new MapperConfiguration(cfg => cfg.CreateMap<Entity.OrderPaymentMade, ServerEntity.OrderPaymentMadeServer>());
        //        var mapper = config.CreateMapper();
        //        OrderPaymentsUpdateServer = mapper.Map<List<Entity.OrderPaymentMade>, List<ServerEntity.OrderPaymentMadeServer>>(orderPaymentsUpdatedLocal);
        //    }


        //        List<OrderLineServer> orderLinesUpdateServer=new List<OrderLineServer>();

           
        //        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Entity.OrderLine, ServerEntity.OrderLineServer>());
        //        var mapper2 = config2.CreateMapper();
        //        orderLinesUpdateServer = mapper2.Map<List<Entity.OrderLine>, List<ServerEntity.OrderLineServer>>(ordersUpdateLocal);
            


        //    ordersUpdateLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_On_Server);
            
        //    orderLinesUpdateServer.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Updated_From_Home);
            
        //    orderPaymentsUpdatedLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_On_Server);

        //    OrderPaymentsUpdateServer.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Updated_From_Home);


        //    try
        //    {
        //        var localDBTransaction = dbLocal.Database.BeginTransaction();
        //        var ServerDBTransaction = dbServer.Database.BeginTransaction();

        //        foreach (var orderLineServer in orderLinesUpdateServer)
        //        {
        //            dbServer.OrderLineServers.Attach(orderLineServer);
        //        }

        //        foreach (var orderPaymentUpdated in OrderPaymentsUpdateServer)
        //        {
        //            dbServer.OrderPaymentMadeServers.Attach(orderPaymentUpdated);
        //        }


        //        dbServer.SaveChanges();
        //        dbLocal.SaveChanges();


        //        localDBTransaction.Commit();
        //        ServerDBTransaction.Commit();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

    }
}
