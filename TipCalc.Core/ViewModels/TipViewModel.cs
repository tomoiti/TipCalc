using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TipCalc.Core.Services;

namespace TipCalc.Core.ViewModels
{
    public class TipViewModel : MvxViewModel
    {
        private readonly ICalculation calculation;
        private double subTotal;
        private int generosity;
        private double tip;

        public double SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; RaisePropertyChanged(() => SubTotal); Recalculate(); }
        }

        public int Generosity
        {
            get { return generosity; }
            set { generosity = value; RaisePropertyChanged(() => Generosity); Recalculate(); }
        }

        public double Tip
        {
            get { return tip; }
            set { tip = value; RaisePropertyChanged(() => Tip); }
        }

        public ICommand OpenSettingsCommand
        {
            get { return new MvxCommand(OpenSettings); }
        }

        public TipViewModel(ICalculation calculation)
        {
            this.calculation = calculation;
        }

        public override void Start()
        {
            subTotal = 100;
            generosity = 10;
            Recalculate();
            base.Start();
        }

        private void Recalculate()
        {
            Tip = calculation.TipAmount(SubTotal, Generosity);
        }

        private void OpenSettings()
        {
            ShowViewModel<SettingsViewModel>();
        }
    }
}
