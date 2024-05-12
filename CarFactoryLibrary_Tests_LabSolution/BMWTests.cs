using CarFactoryLibrary;

namespace CarFactoryLibrary_Tests_LabSolution
{
    public class BMWTests
    {

        /*
         *  1 => Boolean Assert
         *  2 => Numeric Assert
         *  5 => String Asserts
         *  1 => Reference Assert
         *  1 => Type Assert
         *  1 => Exception Assert
         */

        [Fact]
        public void IsMoving_VelocityNotEqualZero_True() //I implemented a new method in car class to test it
        {
            //Arrange
            BMW bmw = new();
            //double currentVelocity = bmw.velocity;  Why here when i use this variable in Assert said fail

            //Act
            bmw.Accelerate();

            //Assert
            Assert.True((bmw.velocity) > 0);
        }

        [Fact]
        public void IncreaseVelocity_valocity15Add15_valocity30() //Is Assert.Equal considerd Numeric or just InRange and NotInRange
        {
            //Arrange
            BMW bmw = new();
            bmw.velocity = 15;
            double addedVelocity = 15;
            //Act
            bmw.IncreaseVelocity(addedVelocity);
            //Assert
            Assert.InRange(bmw.velocity, 10, 30); // 30 is included
        }

        [Fact]
        public void IncreaseVelocity_valocity15Add15_valocity35() //Is Assert.Equal considerd Numeric or just InRange and NotInRange
        {
            //Arrange
            BMW bmw = new();
            bmw.velocity = 15;
            double addedVelocity = 20;
            //Act
            bmw.IncreaseVelocity(addedVelocity);
            //Assert
            Assert.NotInRange(bmw.velocity, 10, 20);
        }


        [Fact]
        public void GetDirection_DirectionForward_Forward()
        {
            //Arrange
            BMW bmw = new();
            bmw.drivingMode = DrivingMode.Forward;

            //Act
            string res = bmw.GetDirection();

            //Assert
            Assert.Equal(DrivingMode.Forward.ToString(), res);
            Assert.StartsWith("For", res);
            Assert.EndsWith("d", res);
        }

        [Fact]
        public void GetDirection_DirectionBackward_Backward()
        {
            //Arrange
            BMW bmw = new();
            bmw.drivingMode = DrivingMode.Backward;

            //Act
            string res = bmw.GetDirection();

            //Assert
            Assert.Contains("Back", res);
            Assert.DoesNotContain("For", res);
        }

        [Fact]
        public void GetMyCar_callFunction_SameCar()
        {
            //Arrange
            BMW bmw = new();

            //Act
            Car car = bmw.GetMyCar();

            //Assert
            Assert.Same(car, bmw);
        }

        [Fact]
        public void NewCar_CarTypeBMW_BMW()
        {
            //Arrange

            //Act
            //BMW Bmw = CarFactory.NewCar(CarTypes.BMW);     // Because return type is Car not BMW ?? We need to make Explicit Casting here to make it work but be aware if it can't cast it will throw exception
            Car? car = CarFactory.NewCar(CarTypes.BMW);

            //Assert
            Assert.IsType<BMW>(car);
        }

        [Fact]
        public void NewCar_CarTypeTesla_Exception() 
        {
            //Arrange


            //Assert        //IN Test Exception We put Act inside Assert itself
            Assert.Throws<NotImplementedException>(() =>
            {
                //Act
                Car? bmw = CarFactory.NewCar(CarTypes.Tesla);
            });


            //NOT WORKING WITH ALL EXCEPTION
            //Assert.Throws<Exception>(() =>
            //{
            //    //Act
            //    Car? bmw = CarFactory.NewCar(CarTypes.Tesla);
            //});


            Assert.ThrowsAny<Exception>(() =>
            {
                Car? bmw = CarFactory.NewCar(CarTypes.Tesla);
            });
        }




    }
}