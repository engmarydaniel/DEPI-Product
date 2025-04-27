using DataAccess.DataBase;
using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository;
using DataAccess;

namespace DataAccess.Repository
{
    public class UnitofWork:IUnitofwork
    {
        private readonly AppDbContext _context;

        public AppUserRepository AppUsers { get; private set; }
        public ProductWishlistRepository ProductWishlists { get; private set; }
        public WishlistRepository Wishlists { get; private set; }
        public AddressRepository Addresses { get; private set; }

        public ProductRepository Products { get; set; }


        public UnitofWork(AppDbContext context, AppUserRepository appUserRepository, ProductWishlistRepository productWishlistRepository, WishlistRepository wishlistRepository, AddressRepository addressRepository, ProductRepository productRepository)
        {
            _context = context;
            AppUsers = appUserRepository;
            ProductWishlists = productWishlistRepository;
            Wishlists = wishlistRepository;
            Addresses = addressRepository;
            Products = productRepository;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
