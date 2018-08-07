using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BogeyCount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        // Create a new list to hold all PeopleAndScores objects
        List<PeopleAndScores> peopleList = new List<PeopleAndScores>();
        // Boolean will be checked when score is entered. If the name entered exists in file it will equal true
        bool nameCheck = false;

        public MainWindow()
        {
            InitializeComponent();
            // Timer for displaying sucessful score entries
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
        }

        private void viewScores_Click(object sender, RoutedEventArgs e)
        {
            enterPanel.Visibility = Visibility.Collapsed;
            allScoresView.Visibility = Visibility.Visible;            
        }

        private void enterScores_Click(object sender, RoutedEventArgs e)
        {
            allScoresView.Visibility = Visibility.Collapsed;
            enterPanel.Visibility = Visibility.Visible;
        }

        private void enterDataBtn_Click(object sender, RoutedEventArgs e)
        {
            // Iterate through list of people and check whether name already exists
            for(int i = 0; i < peopleList.Count; i++)
            {
                // If the name exists, set nameCheck to true. This way the new score and date can be added to that instance. Otherwise a new instance will be created.
                if(nameTxt.Text.ToLower().Equals(peopleList[i].name.ToLower()))
                {
                    nameCheck = true;
                    peopleList[i].dateScores.Add(datePlayed.Text, Convert.ToInt32(scoreTxt.Text));
                    
                }
            }

            if(!nameCheck)
            {
                Dictionary<string, int> copyDateScores = new Dictionary<string, int>();
                copyDateScores.Add(datePlayed.Text, Convert.ToInt32(scoreTxt.Text));
                var newPerson = new PeopleAndScores(nameTxt.Text, copyDateScores);
                peopleList.Add(newPerson);
                
            }
            // Start the timer for displaying the label that shows a score has been entered
            enteredLbl.Visibility = Visibility.Visible;
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            enteredLbl.Visibility = Visibility.Collapsed;
            dispatcherTimer.IsEnabled = false;
        }
    }
}
