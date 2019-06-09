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
    class DownloadNewData
    {
        public void DownloadNewCustomers()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newServerCustomers = dbServer.CustomerServers.Where(aa => aa.StatusCode == (int)ServerDBStatusCode.Added_From_Home).ToList();

            if (newServerCustomers.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ServerEntity.CustomerServer, Entity.Customer>());
            var mapper = config.CreateMapper();
            var customerLocal = mapper.Map< List<ServerEntity.CustomerServer>, List<Entity.Customer>>(newServerCustomers);

            newServerCustomers.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Updated_On_Both_Sides);

            customerLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_From_Server);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();


                dbLocal.Customers.SqlQuery("SET IDENTITY_INSERT [Customer] On");
                dbLocal.Customers.AddRange(customerLocal);
                dbLocal.SaveChanges();
                dbLocal.Customers.SqlQuery("SET IDENTITY_INSERT [Customer] Off");
                dbServer.SaveChanges();



                localDBTransaction.Commit();
                ServerDBTransaction.Commit();
            }
            catch
            {
                throw;
            }
        }

        public void Template()
        {
            //FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            //FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            //var ??server = dbServer..Where(aa => aa.StatusCode == (int)ServerDBStatusCode.Added_From_Home).ToList();

            //var config = new MapperConfiguration(cfg => cfg.CreateMap<ServerEntity., Entity.>());
            //var mapper = config.CreateMapper();
            //var ?? = mapper.Map<List<ServerEntity.>, List<Entity>>();

            //??.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Updated_On_Both_Sides);

            //??.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_From_Server);

            //try
            //{
            //    dbLocal..AddRange();
            //    dbLocal.SaveChanges();
            //    dbServer.SaveChanges();

            //}
            //catch
            //{
            //    throw;
            //}

        }

        public void DownloadNewItems()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newServerItems = dbServer.ItemServers.Where(aa => aa.StatusCode == (int)ServerDBStatusCode.Added_From_Home).ToList();

            if (newServerItems.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ServerEntity.ItemServer, Entity.Item>());
            var mapper = config.CreateMapper();
            var itemsLocal = mapper.Map<List<ServerEntity.ItemServer>, List<Entity.Item>>(newServerItems);

            newServerItems.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Updated_On_Both_Sides);

            itemsLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_From_Server);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();


                dbLocal.Items.SqlQuery("SET IDENTITY_INSERT [Item] On");
                dbLocal.Items.AddRange(itemsLocal);
                dbLocal.SaveChanges();
                dbLocal.Items.SqlQuery("SET IDENTITY_INSERT [Item] Off");
                dbServer.SaveChanges();


                localDBTransaction.Commit();
                ServerDBTransaction.Commit();

            }
            catch
            {
                throw;
            }

        }


        public void DownloadNewOrders()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newServerOrders = dbServer.OrderServers.Where(aa => aa.StatusCode == (int)ServerDBStatusCode.Added_From_Home).ToList();

            if (newServerOrders.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ServerEntity.OrderServer, Entity.Order>());
            var mapper = config.CreateMapper();
            var OrdersLocal = mapper.Map<List<ServerEntity.OrderServer>, List<Entity.Order>>(newServerOrders);

            newServerOrders.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Updated_On_Both_Sides);

            OrdersLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_From_Server);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();


                dbLocal.Orders.SqlQuery("SET IDENTITY_INSERT [Order] On");
                dbLocal.Orders.AddRange(OrdersLocal);
                dbLocal.SaveChanges();
                dbLocal.Orders.SqlQuery("SET IDENTITY_INSERT [Order] Off");
                dbServer.SaveChanges();



                localDBTransaction.Commit();
                ServerDBTransaction.Commit();
            }
            catch
            {
                throw;
            }

        }

        public void DownloadNewOrderLines()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newServerOrderLines = dbServer.OrderLineServers.Where(aa => aa.StatusCode == (int)ServerDBStatusCode.Added_From_Home).ToList();

            if (newServerOrderLines.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ServerEntity.OrderLineServer, Entity.OrderLine>());
            var mapper = config.CreateMapper();
            var OrderLinesLocal = mapper.Map<List<ServerEntity.OrderLineServer>, List<Entity.OrderLine>>(newServerOrderLines);

            newServerOrderLines.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Updated_On_Both_Sides);

            OrderLinesLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_From_Server);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();
                
                dbLocal.OrderLines.SqlQuery("SET IDENTITY_INSERT [OrderLine] On");
                dbLocal.OrderLines.AddRange(OrderLinesLocal);
                dbLocal.SaveChanges();
                dbLocal.OrderLines.SqlQuery("SET IDENTITY_INSERT [OrderLine] Off");
                dbServer.SaveChanges();

                localDBTransaction.Commit();
                ServerDBTransaction.Commit();

            }
            catch
            {
                throw;
            }

        }


        public void DownloadNewOrderPayments()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newServerOrderPaymentMade = dbServer.OrderPaymentMadeServers.Where(aa => aa.StatusCode == (int)ServerDBStatusCode.Added_From_Home).ToList();

            if (newServerOrderPaymentMade.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ServerEntity.OrderPaymentMadeServer, Entity.OrderPaymentMade>());
            var mapper = config.CreateMapper();
            var OrderPaymentLocal = mapper.Map<List<ServerEntity.OrderPaymentMadeServer>, List<Entity.OrderPaymentMade>>(newServerOrderPaymentMade);

            newServerOrderPaymentMade.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Updated_On_Both_Sides);

            OrderPaymentLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_From_Server);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();

                dbLocal.OrderPaymentMades.SqlQuery("SET IDENTITY_INSERT [OrderPaymentMade] On");
                dbLocal.OrderPaymentMades.AddRange(OrderPaymentLocal);
                dbLocal.SaveChanges();
                dbLocal.OrderPaymentMades.SqlQuery("SET IDENTITY_INSERT [OrderPaymentMade] Off");
                dbServer.SaveChanges();

                localDBTransaction.Commit();
                ServerDBTransaction.Commit();

            }
            catch
            {
                throw;
            }
        }

        public void DownloadSupplier()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newServerSuppliers = dbServer.SupplierServers.Where(aa => aa.StatusCode == (int)ServerDBStatusCode.Added_From_Home).ToList();

            if (newServerSuppliers.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ServerEntity.SupplierServer, Entity.Supplier>());
            var mapper = config.CreateMapper();
            var SupplierLocal = mapper.Map<List<ServerEntity.SupplierServer>, List<Entity.Supplier>>(newServerSuppliers);

            newServerSuppliers.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Updated_On_Both_Sides);

            SupplierLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_From_Server);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();

                dbLocal.Suppliers.SqlQuery("SET IDENTITY_INSERT [Supplier] On");
                dbLocal.Suppliers.AddRange(SupplierLocal);
                dbLocal.SaveChanges();
                dbLocal.Suppliers.SqlQuery("SET IDENTITY_INSERT [Supplier] Off");
                dbServer.SaveChanges();

                localDBTransaction.Commit();
                ServerDBTransaction.Commit();

            }
            catch
            {
                throw;
            }

        }

        public void DownloadNewSupplierBankDetail()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newServerSupplierBank = dbServer.SupplierBankDetailServers.Where(aa => aa.StatusCode == (int)ServerDBStatusCode.Added_From_Home).ToList();

            if (newServerSupplierBank.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ServerEntity.SupplierBankDetailServer, Entity.SupplierBankDetail>());
            var mapper = config.CreateMapper();
            var SupplierBankLocal = mapper.Map<List<ServerEntity.SupplierBankDetailServer>, List<Entity.SupplierBankDetail>>(newServerSupplierBank);

            newServerSupplierBank.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Updated_On_Both_Sides);

            SupplierBankLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_From_Server);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();

                dbLocal.SupplierBankDetails.SqlQuery("SET IDENTITY_INSERT [SupplierBankDetail] On");
                dbLocal.SupplierBankDetails.AddRange(SupplierBankLocal);
                dbLocal.SaveChanges();
                dbLocal.SupplierBankDetails.SqlQuery("SET IDENTITY_INSERT [SupplierBankDetail] Off");
                dbServer.SaveChanges();

                localDBTransaction.Commit();
                ServerDBTransaction.Commit();

            }
            catch
            {
                throw;
            }
        }

        public void DownloadNewSupplierDuePayments()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newServerSupplierDuePayments = dbServer.SupplierDuePaymentsServers.Where(aa => aa.StatusCode == (int)ServerDBStatusCode.Added_From_Home).ToList();

            if (newServerSupplierDuePayments.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ServerEntity.SupplierDuePaymentsServer, Entity.SupplierDuePayment>());
            var mapper = config.CreateMapper();
            var SupplierDuePaymentLocal = mapper.Map<List<ServerEntity.SupplierDuePaymentsServer>, List<Entity.SupplierDuePayment>>(newServerSupplierDuePayments);

            newServerSupplierDuePayments.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Updated_On_Both_Sides);

            SupplierDuePaymentLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_From_Server);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();

                dbLocal.SupplierDuePayments.SqlQuery("SET IDENTITY_INSERT [SupplierDuePayments] On");
                dbLocal.SupplierDuePayments.AddRange(SupplierDuePaymentLocal);
                dbLocal.SaveChanges();
                dbLocal.SupplierDuePayments.SqlQuery("SET IDENTITY_INSERT [SupplierDuePayments] Off");
                dbServer.SaveChanges();

                localDBTransaction.Commit();
                ServerDBTransaction.Commit();

            }
            catch
            {
                throw;
            }
        }

        public void DownloadNewSupplierPaymentMade()
        {
            FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
            FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();
            var newServerSupplierPaymentsMade = dbServer.SupplierPaymentMadeServers.Where(aa => aa.StatusCode == (int)ServerDBStatusCode.Added_From_Home).ToList();

            if (newServerSupplierPaymentsMade.Count == 0)
            {
                return;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ServerEntity.SupplierPaymentMadeServer, Entity.SupplierPaymentMade>());
            var mapper = config.CreateMapper();
            var SupplierPaymentMadeLocal = mapper.Map<List<ServerEntity.SupplierPaymentMadeServer>, List<Entity.SupplierPaymentMade>>(newServerSupplierPaymentsMade);

            newServerSupplierPaymentsMade.ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Updated_On_Both_Sides);

            SupplierPaymentMadeLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_From_Server);

            try
            {
                var localDBTransaction = dbLocal.Database.BeginTransaction();
                var ServerDBTransaction = dbServer.Database.BeginTransaction();

                dbLocal.SupplierPaymentMades.SqlQuery("SET IDENTITY_INSERT [SupplierPaymentMade] On");
                dbLocal.SupplierPaymentMades.AddRange(SupplierPaymentMadeLocal);
                dbLocal.SaveChanges();
                dbLocal.SupplierPaymentMades.SqlQuery("SET IDENTITY_INSERT [SupplierPaymentMade] Off");
                dbServer.SaveChanges();

                localDBTransaction.Commit();
                ServerDBTransaction.Commit();

            }
            catch
            {
                throw;
            }
        }


        //public void DownloadOrderReturn()
        //{
        //    FaridiaIronStoreEntities dbLocal = new FaridiaIronStoreEntities();
        //    FaridiaIronStoreServerEntities dbServer = new FaridiaIronStoreServerEntities();

        //    var updatedOrderLinesServer = dbServer.OrderLineServers.Where(aa => aa.StatusCode == (int)ServerDBStatusCode.Updated_From_Home).ToList();
        //    var updatedOrderPaymentsServer= dbServer.OrderPaymentMadeServers.Where(aa => aa.StatusCode == (int)ServerDBStatusCode.Updated_From_Home).ToList();


        //    if (updatedOrderLinesServer.Count==0 && updatedOrderPaymentsServer.Count==0 )
        //    {
        //        return;
        //    }

        //    List<OrderPaymentMade> OrderPaymentMadeUpdatedLocal;

        //    if (updatedOrderPaymentsServer.Count != 0)
        //    {
        //        var config = new MapperConfiguration(cfg => cfg.CreateMap<ServerEntity.OrderPaymentMadeServer, Entity.OrderPaymentMade>());
        //        var mapper = config.CreateMapper();
        //        OrderPaymentMadeUpdatedLocal = mapper.Map<List<ServerEntity.OrderPaymentMadeServer>, List<Entity.OrderPaymentMade>>(updatedOrderPaymentsServer);
        //    }


        //    var config2 = new MapperConfiguration(cfg => cfg.CreateMap<ServerEntity.OrderLineServer, Entity.OrderLine>());
        //    var mapper2 = config2.CreateMapper();
        //    var OrderLineUpdatedLocal = mapper2.Map<List<ServerEntity.OrderLineServer>, List<Entity.OrderLine>>(updatedOrderLinesServer);

        //    .ForEach(aa => aa.StatusCode = (int)ServerDBStatusCode.Updated_On_Both_Sides);

        //    SupplierPaymentMadeLocal.ForEach(aa => aa.StatusCode = (int)LocalDBStatusCode.Updated_From_Server);

        //    try
        //    {
        //        var localDBTransaction = dbLocal.Database.BeginTransaction();
        //        var ServerDBTransaction = dbServer.Database.BeginTransaction();

        //        dbLocal.SupplierPaymentMades.SqlQuery("SET IDENTITY_INSERT [SupplierPaymentMade] On");
        //        dbLocal.SupplierPaymentMades.AddRange(SupplierPaymentMadeLocal);
        //        dbLocal.SaveChanges();
        //        dbLocal.SupplierPaymentMades.SqlQuery("SET IDENTITY_INSERT [SupplierPaymentMade] Off");
        //        dbServer.SaveChanges();

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
