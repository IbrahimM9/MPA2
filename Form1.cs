using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
namespace MPA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        // Dit zorgt ervoor dat het programma wordt afgesloten
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            // Waardes worden aan processStartInfo toegekent

            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "powershell.exe";
            processStartInfo.Arguments = "chkdsk c: /F /R /X";
            processStartInfo.Verb = "RunAs";
            
            // Het process wordt gestart
            Process.Start(processStartInfo);
        }


        private void siticoneDragForm2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void siticoneLabel1_Click(object sender, EventArgs e)
        {

        }

        

        private void siticoneButton4_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {         
            // Dit pakt de %temp% van de gebruiker en verwijdert het vervolgens
            try 
            {
                string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp");

                Directory.Delete(tempPath, true);
            }
            
            // Aan de hand van de exception zal de gebruiker een melding krijgen
            catch (IOException) 
            {
                MessageBox.Show("Sommige bestanden zijn nog in gebruik, deze zijn niet verwijderd.", "Bestanden in gebruik", MessageBoxButtons.OK);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Je hebt niet genoeg rechten om deze bestanden te verwijderen. Start het programma als Administrator", "Toegang geweigerd", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}", "Fout", MessageBoxButtons.OK);
            }
            
        }

        private async void siticoneButton5_Click_1(object sender, EventArgs e)
        {
           // Waardes worden aan processStartInfo gegeven.
     
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "powershell.exe";
            processStartInfo.Arguments = "Clear-RecycleBin -Force Start-Sleep \r\n-Seconds 2 \r\nClear-RecycleBin -Force";
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            
            // Process wordt gestart
            Process.Start(processStartInfo);
            
            // Wacht 2 seconden voordat de melding wordt weergegeven
            await Task.Delay(2000);
            
            // Laat een melding zien dat de prullenbak is leeggemaakt
            MessageBox.Show("Prullenbak is leeggemaakt.");
            
        }
    }
}
