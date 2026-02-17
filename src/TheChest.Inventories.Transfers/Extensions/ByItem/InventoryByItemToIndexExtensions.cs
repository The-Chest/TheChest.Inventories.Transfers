using System;
using TheChest.Core.Containers.Extensions;
using TheChest.Inventories.Containers.Interfaces;
using TheChest.Inventories.Transfers.Validators;

namespace TheChest.Inventories.Transfers.Extensions.ByItem
{
    /// <summary>
    /// Provides extension methods for transferring items between Inventories.
    /// </summary>
    public static class InventoryByItemToIndexExtensions
    {
        /// <summary>
        /// Transfers the specified item from the source inventory to the destination inventory at the specified index.
        /// </summary>
        /// <typeparam name="T">The type of items contained in the inventories.</typeparam>
        /// <param name="source">The inventory from which the item will be transferred.</param>
        /// <param name="item">The item to transfer from the source inventory.</param>
        /// <param name="destination">The inventory to which the item will be added.</param>
        /// <param name="targetIndex">The zero-based index in the destination inventory where the item will be placed.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="targetIndex"/> is less than 0 or greater than or equal to the size of the inventory.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the source inventory does not contain the specified item or if the destination slot at <paramref name="targetIndex"/> is full.</exception>
        public static void TransferTo<T>(this IInventory<T> source, T item, IInventory<T> destination, int targetIndex)
        {
            ContainerArgumentsValidator.Validate(source, destination);
            ContainerIndexValidator.Validate(destination, targetIndex);
           
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            
            if (!source.Contains(item))
                throw new InvalidOperationException("The source inventory does not contain the specified item.");
            if (destination[targetIndex].IsFull)
                throw new InvalidOperationException("The destination slot is full.");

            var itemToTransfer = source.Get(item);

            destination.AddAt(itemToTransfer, targetIndex);
        }
    }
}
