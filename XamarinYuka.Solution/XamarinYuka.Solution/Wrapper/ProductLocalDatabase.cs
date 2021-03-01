using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinYuka.Solution.Constants;
using XamarinYuka.Solution.Models;

namespace XamarinYuka.Solution.Wrapper
{
    public class ProductLocalDatabase
    {

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(ConfigConstant.DatabasePath, ConfigConstant.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public ProductLocalDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ProductModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ProductModel)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<ProductModel>> GetItemsAsync()
        {
            return Database.Table<ProductModel>().ToListAsync();
        }

        public Task<List<ProductModel>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<ProductModel>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<ProductModel> GetItemAsync(string productCode)
        {
            return Database.Table<ProductModel>().Where(i => i.ProductCode == productCode).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ProductModel item, bool isUpdate = false)
        {
            if (isUpdate)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(ProductModel item)
        {
            return Database.DeleteAsync(item);
        }

    }
}
