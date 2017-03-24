namespace Cars.Tests.JustMock
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using System.Collections.Generic;
    using Cars.Models;


    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new MoqCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void SearchingForCarsByMakeShouldReturn2BMW()
        {
            var model = (IList<Car>)this.GetModel(() => this.controller.Search("bmw"));

            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(2, model[0].Id);
            Assert.AreEqual("BMW", model[0].Make);
            Assert.AreEqual("325i", model[0].Model);
            Assert.AreEqual(2008, model[0].Year);

            Assert.AreEqual(3, model[1].Id);
            Assert.AreEqual("BMW", model[1].Make);
            Assert.AreEqual("330d", model[1].Model);
            Assert.AreEqual(2007, model[1].Year);
        }

        [TestMethod]
        public void SearchingForCarsByMakeShouldReturn2BMWWithValues()
        {
            var model = (IList<Car>)this.GetModel(() => this.controller.Search("bmw"));

            Assert.AreEqual(2, model[0].Id);
            Assert.AreEqual("BMW", model[0].Make);
            Assert.AreEqual("325i", model[0].Model);
            Assert.AreEqual(2008, model[0].Year);

            Assert.AreEqual(3, model[1].Id);
            Assert.AreEqual("BMW", model[1].Make);
            Assert.AreEqual("330d", model[1].Model);
            Assert.AreEqual(2007, model[1].Year);
        }

        [TestMethod]
        public void SortedByMakeShouldReturn4Cars()
        {
            var model = (IList<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        public void SortedByMakeShouldReturn4CarsFirstIsAudi()
        {
            var model = (IList<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual("Audi", model[0].Make);
        }

        [TestMethod]
        public void SortedByYearShouldReturn4Cars()
        {
            var model = (IList<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        public void SortedByYearShouldReturn4CarsLastIsOpel()
        {
            var model = (IList<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(2010, model[3].Year);
            Assert.AreEqual("Opel", model[3].Make);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortWithInvalidArgumentShouldThrowException()
        {
            var model = (IList<Car>)this.GetModel(() => this.controller.Sort("foo"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShowDetailsWithAnInvalidIdSHouldThrowException()
        {
            // -1 returns null element
            var model = this.GetModel(() => this.controller.Details(-1));
        }

        [TestMethod]
        public void ShowDetailsWithAnValidIdShouldReturnFirstInList()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(3));
            Assert.AreEqual("Audi", model.Make);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
