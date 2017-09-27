using Microsoft.VisualStudio.TestTools.UnitTesting;
using SondaCapta.Common;
using SondaCapta.Domain.Abstractions;

namespace SondaCappta.Domain.Test
{
    [TestClass]
    public class ProbeTest
    {
        IProbeFactory _probeFactory;

        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void CreateProbePositionTest()
        {
            Position creationPosition1 = new Position(10, 20, Orientation.East);
            Position creationPosition2 = new Position(15, 30, Orientation.West);

            IProbe probe1 = _probeFactory.CreateProbe(creationPosition1);
            IProbe probe2 = _probeFactory.CreateProbe(creationPosition2);

            Assert.AreEqual(creationPosition1.X, probe1.Position.X);
            Assert.AreEqual(creationPosition1.Y, probe1.Position.Y);
            Assert.AreEqual(creationPosition1.Orientation, probe1.Position.Orientation);

            Assert.AreEqual(creationPosition2.X, probe2.Position.X);
            Assert.AreEqual(creationPosition2.Y, probe2.Position.Y);
            Assert.AreEqual(creationPosition2.Orientation, probe2.Position.Orientation);
        }

        [TestMethod]
        public void ProbeTurnTest()
        {
            IProbe probe1 = _probeFactory.CreateProbe(new Position(0, 0, Orientation.North));
            IProbe probe2 = _probeFactory.CreateProbe(new Position(0, 0, Orientation.North));
            IProbe probe3 = _probeFactory.CreateProbe(new Position(0, 0, Orientation.East));
            IProbe probe4 = _probeFactory.CreateProbe(new Position(0, 0, Orientation.East));
            IProbe probe5 = _probeFactory.CreateProbe(new Position(0, 0, Orientation.South));
            IProbe probe6 = _probeFactory.CreateProbe(new Position(0, 0, Orientation.South));
            IProbe probe7 = _probeFactory.CreateProbe(new Position(0, 0, Orientation.West));
            IProbe probe8 = _probeFactory.CreateProbe(new Position(0, 0, Orientation.West));

            probe1.TurnLeft();
            probe2.TurnRight();
            probe3.TurnLeft();
            probe4.TurnRight();
            probe5.TurnLeft();
            probe6.TurnRight();
            probe7.TurnLeft();
            probe8.TurnRight();

            Assert.AreEqual(Orientation.West, probe1.Position.Orientation);
            Assert.AreEqual(Orientation.East, probe2.Position.Orientation);
            Assert.AreEqual(Orientation.North, probe3.Position.Orientation);
            Assert.AreEqual(Orientation.South, probe4.Position.Orientation);
            Assert.AreEqual(Orientation.East, probe5.Position.Orientation);
            Assert.AreEqual(Orientation.West, probe6.Position.Orientation);
            Assert.AreEqual(Orientation.South, probe7.Position.Orientation);
            Assert.AreEqual(Orientation.North, probe8.Position.Orientation);
        }

        [TestMethod]
        public void ProbeMoveTest()
        {
            IProbe probe1 = _probeFactory.CreateProbe(new Position(10, 10, Orientation.North));
            IProbe probe2 = _probeFactory.CreateProbe(new Position(10, 10, Orientation.South));
            IProbe probe3 = _probeFactory.CreateProbe(new Position(10, 10, Orientation.East));
            IProbe probe4 = _probeFactory.CreateProbe(new Position(10, 10, Orientation.West));

            probe1.Move();
            probe2.Move();
            probe3.Move();
            probe4.Move();

            Assert.AreEqual(new Position(10, 11, Orientation.North), probe1.Position);
            Assert.AreEqual(new Position(10, 9, Orientation.South), probe2.Position);
            Assert.AreEqual(new Position(11, 10, Orientation.East), probe3.Position);
            Assert.AreEqual(new Position(9, 10, Orientation.West), probe4.Position);
        }
    }
}
