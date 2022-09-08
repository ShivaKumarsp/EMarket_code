
using EMarket.Data;
using EMarket.Entities;
using EMarket.Entities.Admin;
using EMarket.Entities.Customer;
using EMarket.Entities.Delivery;
using EMarket.Entities.Entities;
using EMarket.Entities.Facilitation;
using EMarket.Entities.HubManager;
using EMarket.Entities.LoginContext;
using EMarket.Entities.Master;
using EMarket.Entities.Models;
using EMarket.Entities.Vendar;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Entities
{

    public class PostgreSqlContext : IdentityDbContext<ApplicationUser, IdentityRole<string>, string>
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options)
            : base(options)
        {
        }


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<IdentityRole> IdentityRole { get; set; }
        public DbSet<Application_RoleDMO> Application_Role_con { get; set; }
        public DbSet<Application_UserDMO> Application_User_con { get; set; }
        public DbSet<Application_Login_LogDMO> Application_Login_Log_con { get; set; }
        public DbSet<Vendor_ProfileDMO> Vendor_Profile_con { get; set; }
        public DbSet<Master_GenderDMO> Master_Gender_con { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Master_LocationDMO> Master_Location_con { get; set; }
        public DbSet<Product_ItemDMO> Product_ItemDMO_con { get; set; }
        public DbSet<Customer_ProfileDMO> Customer_Profile_con { get; set; }
        public DbSet<Customer_AddressDMO> Customer_Address_con { get; set; }
        public DbSet<Master_Product> Master_Product_con { get; set; }
        public DbSet<Cart_ListDMO> Cart_List_con { get; set; }
        public DbSet<Product_SpecificationDMO> Product_Specification_con { get; set; }
        public DbSet<Customer_Shipping_Address_DMO> Customer_Shipping_Address_DMO_con { get; set; }
        public DbSet<Customer_Order_ItemDMO> Customer_Order_ItemDMO_con { get; set; }
        public DbSet<Customer_OrderDMO> Customer_OrderDMO_con { get; set; }
        public DbSet<Online_Payment_TransactionDMO> Payment_TransactionDMO_con { get; set; }
        public DbSet<Online_Payment_Transaction_HistoryDMO> Payment_Transaction_logDMO_con { get; set; }
        public DbSet<Order_Item_txnDMO> Order_Item_txnDMO_con { get; set; }
        public DbSet<Product_Item_SpecificationDMO> product_item_specificationDMO_con { get; set; }
        public DbSet<Additional_CatDMO> Additional_Cat_con { get; set; }
        public DbSet<Salt_StoreDMO> Salt_StoreDMO_con { get; set; }
        public DbSet<Specification_for_VendorDMO> Specification_for_VendorDMO_con { get; set; }
        public DbSet<Master_CategoryDMO> Master_CategoryDMO_con { get; set; }
        public DbSet<Master_SubCategoryDMO> Master_SubCategoryDMO_con { get; set; }
        public DbSet<Master_Attribute_NameDMO> Master_Attribute_NameDMO_con { get; set; }
        public DbSet<Master_SpecificationDMO> Master_SpecificationDMO_con { get; set; }
        public DbSet<Master_Attribute_ValueDMO> Master_Attribute_ValueDMO_con { get; set; }
        public DbSet<Order_Billing_AddressDMO> Order_Billing_AddressDMO_con { get; set; }
        public DbSet<Order_Shipping_AddressDMO> Order_Shipping_AddressDMO_con { get; set; }
        public DbSet<Master_CountryDMO> Master_CountryDMO_con { get; set; }
        public DbSet<Master_StateDMO> Master_StateDMO_con { get; set; }
        public DbSet<Master_Additionalcat_Specification_Map> Master_Additionalcat_Specification_Map_con { get; set; }
        public DbSet<Vendor_Store_DMO> Vendor_Store_DMO_con { get; set; }
        public DbSet<Direct_CheckoutDMO> Direct_CheckoutDMO_con { get; set; }
        public DbSet<POD_CheckDMO> POD_CheckDMO_con { get; set; }
        public DbSet<Payment_Order_QtyDMO> Payment_Order_QtyDMO_con { get; set; }
        public DbSet<Delivery_Executive_DetailsDMO> Delivery_Executive_DetailsDMO_con { get; set; }
        public DbSet<Master_PincodeDMO> Master_PincodeDMO_con { get; set; }
        public DbSet<Master_CityDMO> Master_CityDMO_con { get; set; }
        public DbSet<Hub_RouteDMO> Hub_RouteDMO_con { get; set; }
        public DbSet<Master_HubDMO> Master_HubDMO_con { get; set; }
        public DbSet<Hub_User_DetailsDMO> Hub_User_DetailsDMO_con { get; set; }
        public DbSet<Deliver_Executive_Pincode_MappingDMO> Deliver_Executive_Pincode_MappingDMO_con { get; set; }
        public DbSet<Facilitation_User_DetailsDMO> Facilitation_User_DetailsDMO_con { get; set; }
        public DbSet<Consignment_Batch_TxrDMO> Consignment_BoundleDMO_con { get; set; }
        public DbSet<Consignment_BatchDMO> Consignment_Boundle_txrDMO_con { get; set; }
        public DbSet<Vendor_To_FacilitationDMO> Vendor_To_FacilitationDMO_con { get; set; }
        public DbSet<Facilitation_To_CustomerDMO> Facilitation_To_CustomerDMO_con { get; set; }
        public DbSet<Delivery_Executive_Vehicle_DetailsDMO> Delivery_Executive_Vehicle_DetailsDMO_con { get; set; }
        public DbSet<Facilitation_To_HubDMO> Facilitation_To_HubDMO_con { get; set; }
        public DbSet<Hub_Vehicle_DetailsDMO> Hub_Vehicle_DetailsDMO_con { get; set; }
        public DbSet<Consignment_DMO> Consignment_DMO_con { get; set; }
        public DbSet<Consignment_StatusDMO> Consignment_StatusDMO_con { get; set; }
        public DbSet<Master_FacilitationDMO> Master_FacilitationDMO_con { get; set; }
        public DbSet<Hub_ConsignmentDMO> Hub_ConsignmentDMO_con { get; set; }
        public DbSet<Hub_To_FacilitationDMO> Hub_To_FacilitationDMO_con { get; set; }
        public DbSet<Order_Invoice_AddressDMO> Order_Invoice_AddressDMO_con { get; set; }
        public DbSet<Item_InvoiceDMO> Item_InvoiceDMO_con { get; set; }
        public DbSet<Hub_to_hub_Consignment_TransportDMO> Hub_to_hub_Consignment_TransportDMO_con { get; set; }
        public DbSet<Hub_to_hub_TransportDMO> Hub_to_hub_TransportDMO_con { get; set; }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            //builder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            //builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            //builder.Entity<IdentityUserRole<string>>().ToTable("ApplicationUserRoles");
            //builder.Entity<IdentityUserLogin<string>>().ToTable("ApplicationUserLogins");
            //builder.Entity<IdentityUserClaim<string>>().ToTable("ApplicationUserClaims");
            //builder.Entity<IdentityUserToken<string>>().ToTable("ApplicationUserTokens");
            //builder.Entity<IdentityRoleClaim<string>>().ToTable("ApplicationRoleClaims");


        }

       

        public virtual async Task<long> SaveChangeAsync()
        {
            ChangeTracker.DetectChanges();
            return await base.SaveChangesAsync();
        }

      
    }
}
