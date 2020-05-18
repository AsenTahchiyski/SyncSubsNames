using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SyncSubsNames
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static readonly string[] VideoExtensions = {
            "avi", "mkv", "m4v", "ts", "mp4", "mpg", "mpeg", "mp2", "mpe", "mpv", "m4p", "m4v", "wmv", "mov"};

        private static readonly string[] SubsExtensions = { "sub", "srt" };

        private static readonly string RegexPattern = "([sS](?'Season'[\\d]+))[-_\\s\\.]?([Ee](?'Episode'[\\d]+))";

        private static string selectedFolder;

        private void SelectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        // Get the selected folder
                        string folder = fbd.SelectedPath;
                        selectedFolder = folder;
                        AppendToLog($"Selected folder {folder}.");
                        //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    }
                }
            } 
            catch (Exception exception)
            {
                AppendToLog($"OH SHI$&!@*&% {exception.ToString()}");
            }
        }

        private void Rename_Click(object sender, EventArgs e)
        {
            if (ProcessInnerFolders.Checked)
            {
                ProcessFolderRecursively(selectedFolder);
            }
            else
            {
                ProcessFolder(selectedFolder);
            }
        }

        private void AppendToLog(string text)
        {
            OutputText.Text += text + Environment.NewLine;
        }

        private void ProcessFolderRecursively(string folder)
        {
            ProcessFolder(folder);
            string[] allSubfolders = Directory.GetDirectories(folder);
            foreach(string subfolder in allSubfolders)
            {
                ProcessFolderRecursively(subfolder);
            }
        }

        private void ProcessFolder(string folder)
        {
            string[] allFiles = Directory.GetFiles(folder);

            // Get video files
            var videoFiles = allFiles.Where(file => HasExtension(file, VideoExtensions)).ToArray();
            AppendToLog($"Found {videoFiles.Length} video files.");

            // Get subtitle files
            var subsFiles = allFiles.Where(file => HasExtension(file, SubsExtensions)).ToArray();
            AppendToLog($"Found {subsFiles.Length} subtitle files.");

            // Go through all subtitle files for each video and see if they match
            int subtitlesRenamed = 0;
            foreach (string video in videoFiles)
            {
                foreach (string subtitle in subsFiles)
                {
                    // Rename if necessary
                    if (IsRightSubtitle(subtitle, video) && RenameSubtitle(subtitle, video))
                    {
                        AppendToLog($"Renamed: {Path.GetFileNameWithoutExtension(subtitle)}");
                        subtitlesRenamed++;
                        break;
                    }
                }
            }

            AppendToLog($"{subtitlesRenamed} subtitles renamed.");
            AppendToLog("======================================");
        }

        

        private static bool HasExtension(string fileName, string[] extensions)
        {
            foreach (string extension in extensions)
            {
                if (fileName.EndsWith("." + extension))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsRightSubtitle(string subtitle, string video)
        {
            if (!HasExtension(subtitle, SubsExtensions) || !HasExtension(video, VideoExtensions))
            {
                return false;
            }

            var matchesVideo = Regex.Match(video, RegexPattern);
            var matchesSubtitle = Regex.Match(subtitle, RegexPattern);

            if (!matchesSubtitle.Success || !matchesVideo.Success)
            {
                return false;
            }

            int videoSeason = GetSeason(matchesVideo.Groups);
            int videoEpisode = GetEpisode(matchesVideo.Groups);

            int subtitleSeason = GetSeason(matchesSubtitle.Groups);
            int subtitleEpisode = GetEpisode(matchesSubtitle.Groups);

            // Check if season and episode are same
            if (videoSeason == subtitleSeason && videoEpisode == subtitleEpisode &&
                videoSeason >= 0 && videoEpisode >= 0)
            {
                return true;
            }

            return false;
        }

        private static int GetEpisode(GroupCollection groups)
        {
            foreach (Group group in groups)
            {
                if (group.Name == "Episode")
                {
                    var value = group.Value;
                    if (int.TryParse(value, out int episode))
                    {
                        return episode;
                    }
                }
            }

            return -1;
        }

        private static int GetSeason(GroupCollection groups)
        {
            foreach (Group group in groups)
            {
                if (group.Name == "Season")
                {
                    var value = group.Value;
                    if (int.TryParse(value, out int season))
                    {
                        return season;
                    }
                }
            }

            return -1;
        }

        private static bool RenameSubtitle(string subtitle, string video)
        {
            try
            {
                string oldName = Path.GetFileName(subtitle);
                string newName = Path.GetFileNameWithoutExtension(video) + ".srt";
                string newPath = subtitle.Replace(oldName, newName);
                File.Move(subtitle, newPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void OutputText_TextChanged(object sender, EventArgs e) { }

        private void Form1_Load(object sender, EventArgs e) { }

        //    private void Rename_Click(object sender, EventArgs e)
        //    {

        //    }
    }
}
