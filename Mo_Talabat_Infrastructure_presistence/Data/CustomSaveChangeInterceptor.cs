using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Share;
using Mo_Talabat_Core_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Infrastructure_presistence.Data
{
    internal class CustomSaveChangeInterceptor(ILoggedInUser loggedInUser):SaveChangesInterceptor
    {
        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            return base.SavedChanges(eventData, result);
        }
        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            return base.SavedChangesAsync(eventData, result, cancellationToken);

        }
        public void UpdateEntity( DbContext dbContext)
        {
            if (dbContext is null)return;

            foreach( var entity in dbContext.ChangeTracker.Entries<BaseEntity<int>>().
                Where(e=>e.State is EntityState.Added or EntityState.Modified))
            {
                if (entity.State is EntityState.Added)
                {
                    entity.Entity.CreatedBy = loggedInUser.UserId;
                    entity.Entity.CreatedOn = DateTime.UtcNow;
                }
                entity.Entity.LastModifiedBy = loggedInUser.UserId;
                entity.Entity.LastModifiedOn = DateTime.UtcNow;
            }
        }

    }
}
