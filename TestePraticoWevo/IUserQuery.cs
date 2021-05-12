using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace TestePraticoWevo {
	interface IUserQuery {
		public Task<User> FindOneAsync(int id);
		public Task<List<User>> LatestPostsAsync();
		public Task DeleteAllAsync();
	}
}
