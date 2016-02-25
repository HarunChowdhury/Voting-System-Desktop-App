using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VotingSystemApp.BLL;
using VotingSystemApp.DAL.DAO;

namespace VotingSystemApp
{
    public partial class CandidateEntryUI : Form
    {
        private int winnersNumber;
        private int oldCastVote;
        private int maxCastNo = 0;
        private string emailVotar;
        private string oldEmailVotad;
        private string currentSymbol;
        private CandidateBLL aCandidateBll;
        private Votar aVotar;
        private VotarBLL aVotarBll;
        private CastBLL aCastBll;
        private MixedCandidateCastBLL aMixedCandidateCastBll;
        private Cast aCast;
        public CandidateEntryUI()
        {
            InitializeComponent();
            aCast = new Cast();
            aVotar = new Votar();
            aMixedCandidateCastBll = new MixedCandidateCastBLL();
            aCandidateBll = new CandidateBLL();
            symbolComboBox.DisplayMember = "CandidateSymbol";
            List<Candidate> candidates = new List<Candidate>();
            aCastBll = new CastBLL();
            candidates = aCandidateBll.GetSymbol();
            foreach (Candidate symbol in candidates)
            {
                symbolComboBox.Items.Add(symbol);
            }
        }

        private void candidateSaveButton_Click(object sender, EventArgs e)
        {
            Candidate aCandidate = new Candidate(nameTextBox.Text,symbolTextBox.Text);
            aCandidate.CandidateName = nameTextBox.Text;
            aCandidate.CandidateSymbol = symbolTextBox.Text;

            string msg = aCandidateBll.Save(aCandidate);

            MessageBox.Show(msg);

            symbolComboBox.Items.Add(symbolTextBox.Text);
        }

     

        private void winnerSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Cast aCast = new Cast();
                aCast.MaxNoOfWinners = Convert.ToInt32(winnersNumberTextBox.Text);
                MessageBox.Show("Winners are Saved and Count");
            }
            catch (FormatException formatException)
            {

                MessageBox.Show("Input Number Only and Not keep Blank", formatException.Message);
            }
            catch (OverflowException overflowException)
            {

                MessageBox.Show("Input Number Overflow",overflowException.Message);
            }
           
           
            
        }

        private void castButton_Click(object sender, EventArgs e)
        {
           // Cast aCast = new Cast();
            aVotarBll = new VotarBLL();
            aCastBll= new CastBLL();                                          
            aCast.VotarEmail = emailTextBox.Text;  
            aCast.Symbol= symbolComboBox.Text;   
          //  aVotar.VotarEmail = emailVotar;
            //List<Votar> emails = new List<Votar>();
            //emails = aVotarBll.CollectEmail(aVotar.VotarEmail,winnersNumber);
            //foreach (Votar aEmail in emails)
            //{
                
            //}
          
             maxCastNo = aCast.MaxNoOfWinners;
             
            //if (aCast.MaxNoOfWinners > 0)
            //{
            //    maxCastNo = 1;   
            //}
             string msg = aCastBll.Save(maxCastNo, aCast.Symbol, aCast.VotarEmail);// currentSymbol,emailVotar
            MessageBox.Show(msg);
            aCast.MaxNoOfWinners--;

           

        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            List<MixedCandidateCast> votingResult = new List<MixedCandidateCast>();

           votingResult= aMixedCandidateCastBll.ResultOfVoting();

           foreach (MixedCandidateCast aResult in votingResult)
            {
              //  resultListView.Items.Clear();
                ListViewItem item = new ListViewItem(aResult.Symbol);   
                item.SubItems.Add(aResult.Name);
                item.SubItems.Add(aResult.Status);
                item.SubItems.Add(aResult.NoOfCastVote.ToString());
                resultListView.Items.Add(item);
           
            }

        }

       
    }
}
