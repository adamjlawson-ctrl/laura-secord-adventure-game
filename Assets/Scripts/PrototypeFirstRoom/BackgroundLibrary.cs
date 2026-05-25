using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace PrototypeFirstRoom
{
    [Serializable]
    public class BackgroundEntry
    {
        public string key;
        public Sprite sprite;
    }

    public class BackgroundLibrary : MonoBehaviour
    {
        public List<BackgroundEntry> backgrounds = new List<BackgroundEntry>();

        private Dictionary<string, Sprite> backgroundLookup;
        private const string Scene01Node01ArtFolder = "Assets/Game/Art/Backgrounds/Scene01_Node01_Bedroom/";
        private const string Scene01Node01ResourceFolder = "Backgrounds/Scene01_Node01_Bedroom/";
        private const string Scene01Node02ArtFolder = "Assets/Game/Art/Backgrounds/Scene01_Node02_Kitchen/";
        private const string Scene01Node02ResourceFolder = "Backgrounds/Scene01_Node02_Kitchen/";
        private const string Scene01Node1AArtFolder = "Assets/Game/Art/Backgrounds/Scene01_Node1A_UpstairsLanding/";
        private const string Scene01Node1AResourceFolder = "Backgrounds/Scene01_Node1A_UpstairsLanding/";
        private const string Scene01Node03ArtFolder = "Assets/Game/Art/Backgrounds/Scene01_Node03_FrontHall/";
        private const string Scene01Node03ResourceFolder = "Backgrounds/Scene01_Node03_FrontHall/";
        private const string Scene01Node03BArtFolder = "Assets/Game/Art/Backgrounds/Scene01_Node03B_ParlourEavesdrop/";
        private const string Scene01Node03BResourceFolder = "Backgrounds/Scene01_Node03B_ParlourEavesdrop/";

        private struct ExpectedBackgroundSource
        {
            public string editorArtFolder;
            public string resourceFolder;
            public string fileName;

            public ExpectedBackgroundSource(string editorArtFolder, string resourceFolder, string fileName)
            {
                this.editorArtFolder = editorArtFolder;
                this.resourceFolder = resourceFolder;
                this.fileName = fileName;
            }
        }

        private static readonly Dictionary<string, ExpectedBackgroundSource> ExpectedBackgroundByKey =
            new Dictionary<string, ExpectedBackgroundSource>(StringComparer.OrdinalIgnoreCase)
            {
                {
                    "S01_N01_1N",
                    new ExpectedBackgroundSource(
                        Scene01Node01ArtFolder,
                        Scene01Node01ResourceFolder,
                        "Scene01_Node01_1N_Bedroom_North.png")
                },
                {
                    "S01_N01_1E",
                    new ExpectedBackgroundSource(
                        Scene01Node01ArtFolder,
                        Scene01Node01ResourceFolder,
                        "Scene01_Node01_1E_Wardrobe_Shawl.png")
                },
                {
                    "S01_N01_1S",
                    new ExpectedBackgroundSource(
                        Scene01Node01ArtFolder,
                        Scene01Node01ResourceFolder,
                        "Scene01_Node01_1S_Children_Keepsakes.png")
                },
                {
                    "S01_N01_1W",
                    new ExpectedBackgroundSource(
                        Scene01Node01ArtFolder,
                        Scene01Node01ResourceFolder,
                        "Scene01_Node01_1W_Bedroom_Doorway.png")
                },
                {
                    "S01_N02_2N",
                    new ExpectedBackgroundSource(
                        Scene01Node02ArtFolder,
                        Scene01Node02ResourceFolder,
                        "Scene01_Node02_2N_Hearth_and_Chimney.png")
                },
                {
                    "S01_N02_2E",
                    new ExpectedBackgroundSource(
                        Scene01Node02ArtFolder,
                        Scene01Node02ResourceFolder,
                        "Scene01_Node02_2E_Mess_Tins_and_Ration_Slip.png")
                },
                {
                    "S01_N02_2S",
                    new ExpectedBackgroundSource(
                        Scene01Node02ArtFolder,
                        Scene01Node02ResourceFolder,
                        "Scene01_Node02_2S_Kitchen_South_Sideboard_View.png")
                },
                {
                    "S01_N02_2W",
                    new ExpectedBackgroundSource(
                        Scene01Node02ArtFolder,
                        Scene01Node02ResourceFolder,
                        "Scene01_Node02_2W_Back_Door_and_Fog.png")
                },
                {
                    "S01_N1A_1A-S",
                    new ExpectedBackgroundSource(
                        Scene01Node1AArtFolder,
                        Scene01Node1AResourceFolder,
                        "Scene01_Node1A_1A-S_Top_of_Stairs.png")
                },
                {
                    "S01_N1A_1A-N",
                    new ExpectedBackgroundSource(
                        Scene01Node1AArtFolder,
                        Scene01Node1AResourceFolder,
                        "Scene01_Node1A_1A-N_Children_Rooms.png")
                },
                {
                    "S01_N1A_1A-W",
                    new ExpectedBackgroundSource(
                        Scene01Node1AArtFolder,
                        Scene01Node1AResourceFolder,
                        "Scene01_Node1A_1A-W_Blank_Landing_Wall.png")
                },
                {
                    "S01_N03_3E",
                    new ExpectedBackgroundSource(
                        Scene01Node03ArtFolder,
                        Scene01Node03ResourceFolder,
                        "Scene01_Node03_3E_Coat_Hooks_Window.png")
                },
                {
                    "S01_N03_3N",
                    new ExpectedBackgroundSource(
                        Scene01Node03ArtFolder,
                        Scene01Node03ResourceFolder,
                        "Scene01_Node03_3N_Stair_and_Wall.png")
                },
                {
                    "S01_N03_3S",
                    new ExpectedBackgroundSource(
                        Scene01Node03ArtFolder,
                        Scene01Node03ResourceFolder,
                        "Scene01_Node03_3S_Parlour_Side_Hall.png")
                },
                {
                    "S01_N03_3W",
                    new ExpectedBackgroundSource(
                        Scene01Node03ArtFolder,
                        Scene01Node03ResourceFolder,
                        "Scene01_Node03_3W_Toward_Kitchen.png")
                },
                {
                    "S01_N03B_3B-N",
                    new ExpectedBackgroundSource(
                        Scene01Node03BArtFolder,
                        Scene01Node03BResourceFolder,
                        "Scene01_Node03B_3B-N_Parlour_Eavesdrop.png")
                },
                {
                    "S01_N03B_P_BROWNELL",
                    new ExpectedBackgroundSource(
                        Scene01Node03BArtFolder,
                        Scene01Node03BResourceFolder,
                        "Scene01_Node03B_Officer_Senior.png")
                },
                {
                    "S01_N03B_P_PARKER",
                    new ExpectedBackgroundSource(
                        Scene01Node03BArtFolder,
                        Scene01Node03BResourceFolder,
                        "Scene01_Node03B_Officer_Standard.png")
                },
                {
                    "S01_N03B_P_DUNBAR",
                    new ExpectedBackgroundSource(
                        Scene01Node03BArtFolder,
                        Scene01Node03BResourceFolder,
                        "Scene01_Node03B_Officer_Young.png")
                }
            };

        private void Awake()
        {
            RebuildLookup();
        }

        private void OnValidate()
        {
#if UNITY_EDITOR
            AutoWireExpectedEntries();
#endif
            RebuildLookup();
        }

        public Sprite GetSprite(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            if (backgroundLookup == null)
            {
                RebuildLookup();
            }

            Sprite sprite;
            if (backgroundLookup != null && backgroundLookup.TryGetValue(key, out sprite) && sprite != null)
            {
                return sprite;
            }

            return LoadDefaultResourceSprite(key);
        }

        public bool HasEntry(string key)
        {
            if (string.IsNullOrWhiteSpace(key) || backgrounds == null)
            {
                return false;
            }

            foreach (var entry in backgrounds)
            {
                if (entry == null || string.IsNullOrWhiteSpace(entry.key))
                {
                    continue;
                }

                if (string.Equals(entry.key, key, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool HasDefaultResourceMapping(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return false;
            }

            return ExpectedBackgroundByKey.ContainsKey(key);
        }

        public static Sprite LoadDefaultResourceSprite(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            ExpectedBackgroundSource expectedSource;
            if (!ExpectedBackgroundByKey.TryGetValue(key, out expectedSource))
            {
                return null;
            }

#if UNITY_EDITOR
            var editorAssetPath = expectedSource.editorArtFolder + expectedSource.fileName;
            var editorSprite = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(editorAssetPath);
            if (editorSprite != null)
            {
                return editorSprite;
            }
#endif

            var resourcePath = expectedSource.resourceFolder + Path.GetFileNameWithoutExtension(expectedSource.fileName);
            return Resources.Load<Sprite>(resourcePath);
        }

#if UNITY_EDITOR
        private void AutoWireExpectedEntries()
        {
            if (backgrounds == null)
            {
                backgrounds = new List<BackgroundEntry>();
            }

            foreach (var kvp in ExpectedBackgroundByKey)
            {
                var key = kvp.Key;
                var entry = FindEntry(key);
                if (entry == null)
                {
                    entry = new BackgroundEntry { key = key, sprite = null };
                    backgrounds.Add(entry);
                }

                var assetPath = kvp.Value.editorArtFolder + kvp.Value.fileName;
                var sprite = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
                if (sprite != null && entry.sprite != sprite)
                {
                    entry.sprite = sprite;
                }
            }
        }

        private BackgroundEntry FindEntry(string key)
        {
            if (backgrounds == null)
            {
                return null;
            }

            foreach (var entry in backgrounds)
            {
                if (entry == null || string.IsNullOrWhiteSpace(entry.key))
                {
                    continue;
                }

                if (string.Equals(entry.key, key, StringComparison.OrdinalIgnoreCase))
                {
                    return entry;
                }
            }

            return null;
        }
#endif

        private void RebuildLookup()
        {
            if (backgroundLookup == null)
            {
                backgroundLookup = new Dictionary<string, Sprite>(StringComparer.OrdinalIgnoreCase);
            }
            else
            {
                backgroundLookup.Clear();
            }

            if (backgrounds == null)
            {
                return;
            }

            foreach (var entry in backgrounds)
            {
                if (entry == null || string.IsNullOrWhiteSpace(entry.key))
                {
                    continue;
                }

                backgroundLookup[entry.key] = entry.sprite;
            }
        }
    }
}
