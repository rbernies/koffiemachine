
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KoffieMachineDomain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using TeaAndChocoLibrary;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Dictionary<string, double> _cashOnCards;
        public ObservableCollection<string> LogText { get; private set; }
        private CoffeeFactory _coffeeFactory;
        private TeaBlendRepository _teaBlendRepo;

        public MainViewModel()
        {
            _coffeeStrength = Strength.Normal;
            _sugarAmount = Amount.Normal;
            _milkAmount = Amount.Normal;

            LogText = new ObservableCollection<string>();
            LogText.Add("Starting up...");
            LogText.Add("Done, what would you like to drink?");

            _cashOnCards = new Dictionary<string, double>();
            _cashOnCards["Arjen"] = 5.0;
            _cashOnCards["Bert"] = 3.5;
            _cashOnCards["Chris"] = 7.0;
            _cashOnCards["Daan"] = 6.0;
            PaymentCardUsernames = new ObservableCollection<string>(_cashOnCards.Keys);
            SelectedPaymentCardUsername = PaymentCardUsernames[0];
            _coffeeFactory = new CoffeeFactory();
            _teaBlendRepo = new TeaBlendRepository();
            TeaBlends = new ObservableCollection<string>(_teaBlendRepo.BlendNames);
            
        }

        #region Drink properties to bind to
        private Drink _selectedDrink;
        public string SelectedDrinkName
        {
            get { return _selectedDrink?.Name; }
        }

       
       public string SelectedTeaBlend { get; set; }

        public double? SelectedDrinkPrice
        {
            get { return _selectedDrink?.GetPrice(); }
        }
        #endregion Drink properties to bind to

        #region Payment
        public RelayCommand PayByCardCommand => new RelayCommand(() =>
        {
            Payment pay = new Payment(_cashOnCards[SelectedPaymentCardUsername], RemainingPriceToPay);
            if (_selectedDrink != null)
            {
                LogText.Add(pay.PayByCard(_cashOnCards[SelectedPaymentCardUsername], RemainingPriceToPay));
                RemainingPriceToPay = pay.Price;
                _cashOnCards[SelectedPaymentCardUsername] = pay.Balance;
            }
            RaisePropertyChanged(() => PaymentCardRemainingAmount);
            makeCoffee();
        });

        public ICommand PayByCoinCommand => new RelayCommand<double>(coinValue =>
        {
            Payment pay = new Payment(coinValue, RemainingPriceToPay);
            LogText.Add(pay.PayWithCoins());
            RemainingPriceToPay = pay.Price;
            makeCoffee();
        });

        private void makeCoffee()
        {
            if (_selectedDrink != null && RemainingPriceToPay == 0)
            {
                _selectedDrink.LogDrinkMaking(LogText);
                _selectedDrink.FinishDrink(LogText);
                LogText.Add("------------------");
                _selectedDrink = null;
            }
        }
       
        public double PaymentCardRemainingAmount => _cashOnCards.ContainsKey(SelectedPaymentCardUsername ?? "") ? _cashOnCards[SelectedPaymentCardUsername] : 0;

        public ObservableCollection<string> PaymentCardUsernames { get; set; }
        private string _selectedPaymentCardUsername;
        public string SelectedPaymentCardUsername
        {
            get { return _selectedPaymentCardUsername; }
            set
            {
                _selectedPaymentCardUsername = value;
                RaisePropertyChanged(() => SelectedPaymentCardUsername);
                RaisePropertyChanged(() => PaymentCardRemainingAmount);
            }
        }

        private double _remainingPriceToPay;
        public double RemainingPriceToPay
        {
            get { return _remainingPriceToPay; }
            set { _remainingPriceToPay = value; RaisePropertyChanged(() => RemainingPriceToPay); }
        }
        #endregion Payment

        #region Coffee buttons
        private Strength _coffeeStrength;
        public Strength CoffeeStrength
        {
            get { return _coffeeStrength; }
            set { _coffeeStrength = value; RaisePropertyChanged(() => CoffeeStrength); }
        }

        private Amount _sugarAmount;
        public Amount SugarAmount
        {
            get { return _sugarAmount; }
            set { _sugarAmount = value; RaisePropertyChanged(() => SugarAmount); }
        }

        private Amount _milkAmount;
        public Amount MilkAmount
        {
            get { return _milkAmount; }
            set { _milkAmount = value; RaisePropertyChanged(() => MilkAmount); }
        }

        public ObservableCollection<string> TeaBlends { get; set; }

        public ICommand DrinkCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = null;

            _selectedDrink = _coffeeFactory.SelectCoffee(drinkName, CoffeeStrength, SugarAmount, MilkAmount, _teaBlendRepo.GetTeaBlend(SelectedTeaBlend));
                              
            if(_selectedDrink != null)
            {
                RemainingPriceToPay = _selectedDrink.GetPrice();
           
                LogText.Add($"Selected {_selectedDrink.Name} " + _coffeeFactory.GetSugarMilkInfo() + $", price: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}");
                RaisePropertyChanged(() => RemainingPriceToPay);
                RaisePropertyChanged(() => SelectedDrinkName);
                RaisePropertyChanged(() => SelectedDrinkPrice);
            } else
            {
                    LogText.Add($"Could not make {drinkName}, recipe not found.");
                }
        });
        #endregion Coffee buttons
    }
}