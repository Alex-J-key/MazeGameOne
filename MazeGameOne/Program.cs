namespace MazeGameOne
{
    /*
 TCreative Commons Attribution-NonCommercial 4.0 International
 (CC BY-NC 4.0)

 Copyright © 2025 Alexander Keyser
 https://Website-ajk.uk

 This project is licensed under the Creative Commons
 Attribution-NonCommercial 4.0 International License.

 Full license text:
 https://creativecommons.org/licenses/by-nc/4.0/
 Or open the LICENSE File within this project
 */

    /*
     "MazeGameOne" is a maze type game where you attempt to reach the green cell.
     This is Version 2.0
    */
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}