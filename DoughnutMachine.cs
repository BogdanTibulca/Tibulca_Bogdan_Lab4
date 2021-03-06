using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Threading;

namespace Tibulca_Bogdan_Lab2
{
    class DoughnutMachine : System.ComponentModel.Component
    {
        private DoughnutType mFlavor;
        private System.Collections.ArrayList mDoughnuts = new System.Collections.ArrayList();
        public delegate void DoughnutCompleteDelegate();
        public event DoughnutCompleteDelegate DoughnutComplete;
        DispatcherTimer doughnutTimer;

        public DoughnutMachine()
        {
            InitializeComponent();
        }

        public DoughnutType Flavor
        {
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }

        public Doughnut this[int Index]
        {
            get
            {
                return (Doughnut)mDoughnuts[Index];

            }
            set
            {
                mDoughnuts[Index] = value;
            }
        }

        private void InitializeComponent()
        {
            this.doughnutTimer = new DispatcherTimer();
            this.doughnutTimer.Tick += new EventHandler(this.doughnutTimer_Tick);
        }

        private void doughnutTimer_Tick(object sender, EventArgs e)
        {
            Doughnut aDoughnut = new Doughnut(this.Flavor);
            mDoughnuts.Add(aDoughnut);
            DoughnutComplete();
        }

        public bool Enabled
        {
            set
            {
                doughnutTimer.IsEnabled = value;
            }
        }
        public int Interval
        {
            set
            {
                doughnutTimer.Interval = new TimeSpan(0, 0, value);
            }
        }

        public void MakeDoughnuts(DoughnutType dFlavor)
        {
            Flavor = dFlavor;
            switch (Flavor)
            {
                case DoughnutType.Glazed: Interval = 3; break;
                case DoughnutType.Sugar: Interval = 2; break;
                case DoughnutType.Lemon: Interval = 5; break;
                case DoughnutType.Chocolate: Interval = 7; break;
                case DoughnutType.Vanilla: Interval = 4; break;
            }
            doughnutTimer.Start();
        }
    }
    public enum DoughnutType
    {
        Glazed,
        Sugar,
        Lemon,
        Chocolate,
        Vanilla
    }

    class Doughnut
    {
        private DoughnutType mFlavor;
        private readonly DateTime mTimeOfCreation;
        private float mPrice = .50F;

        public DoughnutType Flavor
        {
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }

        public float Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }

        public DateTime TimeOfCreation
        {
            get
            {
                return mTimeOfCreation;
            }
        }
        public Doughnut(DoughnutType aFlavor)
        {
            mTimeOfCreation = DateTime.Now;
            mFlavor = aFlavor;
        }
    }

}
