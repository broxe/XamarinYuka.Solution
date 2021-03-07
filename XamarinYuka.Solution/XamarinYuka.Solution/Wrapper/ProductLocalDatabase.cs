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
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ProductEntityModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ProductEntityModel)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<ProductEntityModel>> GetItemsAsync()
        {
            return Database.Table<ProductEntityModel>().ToListAsync();
        }

        public Task<List<ProductEntityModel>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<ProductEntityModel>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<ProductEntityModel> GetItemAsync(string productCode)
        {
            return Database.Table<ProductEntityModel>().Where(i => i.ProductCode == productCode).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ProductEntityModel item, bool isUpdate = false)
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

        public Task<int> DeleteItemAsync(ProductEntityModel item)
        {
            return Database.DeleteAsync(item);
        }

        public Task<int> DeleteItemByCode(string codeItem)
        {
            return Database.ExecuteAsync($"DELETE FROM ProductEntityModel WHERE ProductCode = {codeItem}");
        }

    }
}
