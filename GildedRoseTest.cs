using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        /// <summary>
        /// Aged Brie : Quality increase whith time.
        /// Quality can't be greater than 50
        /// </summary>
        [Test]
        public void AgedQualityIncreaseWithTime()
        {
            int maxValue = 50;

            //Arrange 
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 5 } };
            GildedRose _sut = new GildedRose(Items);

            //Act
            int originalValueQuality = Items[0].Quality;

            while (Items[0].Quality < maxValue)
            {
                _sut.UpdateQuality();
            }

            // if we repeat the operation, the quality couldn't be greater than 50
            _sut.UpdateQuality();
            _sut.UpdateQuality();

            //Assert

            // Quantity must be greater than the original one and it can't be greater than 50

            Assert.IsTrue(Items[0].Name == "Aged Brie");
            Assert.Greater(Items[0].Quality, originalValueQuality); // Quantity must be greater than the original one
            Assert.AreEqual(Items[0].Quality, maxValue); // after 50 days the quantity must be equal to 50
        }

        /// <summary>
        /// Backstage Pass: Quality increases with time.
        /// Quality increases by 2 when there are 10 days or less
        /// Quality increases by 3 when there are 5 days or less
        /// </summary>
        [Test]
        public void BackstagePasseQualityincreases()
        {
            int initQuality = 20;
            int step10days = initQuality + 2;
            int step5days = initQuality + 3;

            //Arrange 
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = initQuality },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = initQuality } };
            GildedRose _sut = new GildedRose(Items);

            //Act

            _sut.UpdateQuality();

            //Assert

            Assert.IsTrue(Items[0].Name == "Backstage passes to a TAFKAL80ETC concert");
            Assert.AreEqual(Items[0].Quality, step10days); // Quality increases by 2 when there are 10 days or less
            Assert.AreEqual(Items[1].Quality, step5days); // Quality increases by 3 when there are 5 days or less
        }

        /// <summary>
        /// Backstage Pass: Quality increases with time.
        /// After concert quality = 0, concert means that the date is exceeded SellIn less than 0
        /// </summary>
        [Test]
        public void BackstagePasseConcert()
        {
            int initQuality = 20;

            //Arrange 
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = initQuality }};
            GildedRose _sut = new GildedRose(Items);

            //Act

            _sut.UpdateQuality();

            //Assert

            Assert.IsTrue(Items[0].Name == "Backstage passes to a TAFKAL80ETC concert");
            Assert.AreEqual(Items[0].Quality, 0); // After concert quality = 0, concert means that the date is exceeded SellIn less than 0
        }

        /// <summary>
        /// Backstage Pass: Quality increases with time.
        /// Quality can't be greater than 50
        /// Quality increases by 2 when there are 10 days or less
        /// Quality increases by 3 when there are 5 days or less
        /// After concert quality = 0, concert means that the date is exceeded SellIn less than 0
        /// </summary>
        [Test]
        public void BackstagePasseIncreaseWithTime()
        {
            //Arrange 
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 50, Quality = 5 } };
            GildedRose _sut = new GildedRose(Items);

            //Act
            while (Items[0].Quality != 0)
            {
                _sut.UpdateQuality();
            }

            //Assert

            // Quality must be 0 and SellIn must be negative

            Assert.IsTrue(Items[0].Name == "Backstage passes to a TAFKAL80ETC concert");
            Assert.IsTrue(Items[0].SellIn < 0); // SellIn must be negative
            Assert.IsTrue(Items[0].Quality == 0); // Quantity must be 0
        }

        /// <summary>
        /// Sulfuras: no expiry date and never loses in quality
        /// quality = 80 because legendary object
        /// </summary>
        [Test]
        public static void SulfrasNotChangeWithTime()
        {
            //Arrange 
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            GildedRose _sut = new GildedRose(Items);

            var oldQuality = Items[0].Quality;
            var oldSellIn = Items[0].SellIn;

            //Act
            for (int i = 0; i < 50; i++)
            {
                _sut.UpdateQuality();
            }

            //Assert

            // Sulfuras is a legendary element so nothing must change

            Assert.IsTrue(Items[0].Name == "Sulfuras, Hand of Ragnaros");
            Assert.AreEqual(Items[0].SellIn, oldSellIn); // SellIn must not change
            Assert.AreEqual(Items[0].Quality, oldQuality); // Quality must not change
        }

        /// <summary>
        /// Element: Quality greater or egal 0 and quality less than 50
        /// </summary>
        [Test]
        public void ElementDecrease()
        {
            //Arrange 
            int initQuality = 50;
            IList<Item> Items = new List<Item> {
                new Item { Name = "Element 1", SellIn = 30, Quality = initQuality }
            };

            GildedRose _sut = new GildedRose(Items);

            //Act

            // 50-day test
            for (int i = 0; i < 50; i++)
            {
                _sut.UpdateQuality();
            }

            //Assert

            Assert.Less(Items[0].Quality, initQuality); // Quality less than 50
            Assert.GreaterOrEqual(Items[0].Quality, 0); // Quality greater or egal 0 
        }

        /// <summary>
        /// Element: the quality decreases by 1 each passing day
        /// </summary>
        [Test]
        public void ElementDecreaseByOne()
        {
            //Arrange 
            int initQuality = 50;
            IList<Item> Items = new List<Item> {
                new Item { Name = "Element 1", SellIn = 30, Quality = initQuality }
            };

            GildedRose _sut = new GildedRose(Items);

            //Act
            _sut.UpdateQuality();

            //Assert
            Assert.AreEqual(Items[0].Quality, initQuality - 1); // no element with a positive SellIn
        }

        /// <summary>
        /// Element: when SellIn is less than or equal to 0 quality decreases by 2 each day
        /// </summary>
        [Test]
        public void ElementDecreaseSellInNegatif()
        {
            //Arrange 
            int initQuality = 50;
            IList<Item> Items = new List<Item> {
                new Item { Name = "Element 1", SellIn = -1, Quality = initQuality }
            };

            GildedRose _sut = new GildedRose(Items);

            //Act
            _sut.UpdateQuality();

            //Assert
            Assert.AreEqual(Items[0].Quality, initQuality - 2); // no element with a positive SellIn
        }

        /// <summary>
        /// Element: Quality greater or egal 0 and quality less than 50
        /// the quality decreases by 1 each passing day
        /// when SellIn is less than or equal to 0 quality decreases by 2 each day
        /// </summary>
        [Test]
        public void ElementDecreaseWithTime()
        {
            //Arrange 
            IList<Item> Items = new List<Item> {
                new Item { Name = "Element 1", SellIn = 0, Quality = 0 },
                new Item { Name = "Element 2", SellIn = 10, Quality = 20 },
                new Item { Name = "Element 3", SellIn = 20, Quality = 30 },
                new Item { Name = "Element 4", SellIn = 30, Quality = 40 },
                new Item { Name = "Element 5", SellIn = 40, Quality = 50 }
            };

            GildedRose _sut = new GildedRose(Items);

            //Act

            // 50-day test
            for (int i = 0; i < 50; i++)
            {
                _sut.UpdateQuality();
            }

            //Assert

            // After 50 days there must be no element with a positive SellIn and quality greater than 0 and less than 0

            Assert.IsTrue(!Items.Any(o => o.SellIn > 0)); // no element with a positive SellIn
            Assert.IsTrue(Items.Count(o => o.SellIn < 0) == Items.Count); // all the elements on a negative SellIn

            Assert.IsTrue(!Items.Any(o => o.Quality > 0)); // none greater than 0
            Assert.IsTrue(!Items.Any(o => o.Quality < 0)); // none less than 0
            Assert.IsTrue(Items.Count(o => o.Quality == 0) == Items.Count); // all equal to 0
        }

        /// <summary>
        /// Conjured: 
        /// The quantity decreases 2 times faster than an element so:
        /// - the quality decreases by 2 each passing day
        /// </summary>
        [Test]
        public void ConjuredDecreaseByTwo()
        {
            //Arrange 
            int initQuality = 50;
            IList<Item> Items = new List<Item> {
                new Item { Name = "Conjured Mana Cake", SellIn = 20, Quality = initQuality }
            };

            GildedRose _sut = new GildedRose(Items);

            //Act
            _sut.UpdateQuality();


            //Assert
            Assert.AreEqual(Items[0].Quality, initQuality - 2); // the quality decreases by 2 each passing day
        }

        /// <summary>
        /// Conjured: 
        /// The quantity decreases 2 times faster than an element so:
        /// - When SellIn is less than or equal to 0 0 quality decreases by 4 each day
        /// </summary>
        [Test]
        public void ConjuredDecreaseByFour()
        {
            //Arrange 
            int initQuality = 50;
            IList<Item> Items = new List<Item> {
                new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = initQuality }
            };

            GildedRose _sut = new GildedRose(Items);

            //Act
            _sut.UpdateQuality();


            //Assert
            Assert.AreEqual(Items[0].Quality, initQuality - 4); // When SellIn is less than or equal to 0 0 quality decreases by 4 each day
        }

        /// <summary>
        /// Conjured: Quality greater than 0 and quality less than 50
        /// The quantity decreases 2 times faster than an element so:
        /// - the quality decreases by 2 each passing day
        /// - When SellIn is less than or equal to 0 0 quality decreases by 4 each day

        /// </summary>
        [Test]
        public void ConjuredDecreaseWithTime()
        {
            //Arrange 
            IList<Item> Items = new List<Item> {
                new Item { Name = "Conjured Mana Cake", SellIn = 20, Quality = 50 },
                new Item { Name = "Element", SellIn = 20, Quality = 50 }
            };

            GildedRose _sut = new GildedRose(Items);

            //Act

            // 50 - day test
            for (int i = 0; i < 50; i++)
            {
                _sut.UpdateQuality();
            }

            //Assert

            //After 50 days there must be no element with a positive SellIn and quality greater than 0 and less than 0

            Assert.IsTrue(!Items.Any(o => o.SellIn > 0)); // no element with a positive SellIn
            Assert.IsTrue(Items.Count(o => o.SellIn < 0) == Items.Count); // all the elements on a negative SellIn

            Assert.IsTrue(!Items.Any(o => o.Quality > 0)); // none greater than 0
            Assert.IsTrue(!Items.Any(o => o.Quality < 0)); // none less than 0
            Assert.IsTrue(Items.Count(o => o.Quality == 0) == Items.Count); // all equal to 0
        }
    }
}
