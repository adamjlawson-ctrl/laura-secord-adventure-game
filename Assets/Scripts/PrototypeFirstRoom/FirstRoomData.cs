using System.Collections.Generic;
using UnityEngine;

namespace PrototypeFirstRoom
{
    public static class FirstRoomData
    {
        public const string StartViewId = "1N";
        public const string Node1ATopOfStairsViewId = "1A-S";
        public const string Node3FrontHallEntryViewId = "3E";
        public const string Node2KitchenEntryViewId = "2N";
        public const string Node3BEavesdropViewId = "3B-N";
        public const string Node1WarningCutsceneViewId = "1N-WARN";
        public const string Node4FrontYardEntryViewId = "4E";
        public const string Node5EntryViewId = "5N";
        public const string Node6EntryViewId = "6N";
        public const string Node7EntryViewId = "7W";
        public const string Node8EntryViewId = "8W";
        public const string Node9EntryViewId = "9W";
        public const string Node10EntryViewId = "10W";
        public const string Node11EntryViewId = "11W";
        public const string Node12EntryViewId = "12W";
        public const string Node13EntryViewId = "13W";
        public const string Node14EntryViewId = "14W";
        public const string Node15EntryViewId = "15W";
        public const string Node16EntryViewId = "16W";
        public const string Node17EntryViewId = "17W";
        public const string Node18EntryViewId = "18W";
        public const string Node19EntryViewId = "19W";
        public const string Node20EntryViewId = "20W";
        public const string Node21EntryViewId = "21W";
        public const string Node22EntryViewId = "22W";
        public const string Node23EntryViewId = "23W";
        public const string Node24EntryViewId = "24W";
        public const string Node25EntryViewId = "25W";
        public const string Node26EntryViewId = "26W";
        public const string Node27EntryViewId = "27W";
        public const string Node27MeetingCutsceneViewId = "27-MEET";
        public const string Node28EntryViewId = "28W";
        public const string Node29EntryViewId = "29W";
        public const string Node30EntryViewId = "30W";
        public const string Node30ThresholdCutsceneViewId = "30-THRESH";
        public const string Node31EntryViewId = "31W";
        public const string Node32EntryViewId = "32W";
        public const string Node33WarningCutsceneViewId = "33-WARN";
        public const string Node33EntryViewId = "33W";
        public const string Node34EntryViewId = "34W";
        public const string Node35EntryViewId = "35W";
        public const string Node36EntryViewId = "36W";
        public const string Node37PlaceholderTarget = "37W";
        public const string Node37PlaceholderMessage = "Act III Scene 4 not implemented yet: The Night March to Beaver Dams begins next.";
        public const string Alt4CutsceneViewId = "ALT4";
        public const string Alt5CutsceneViewId = "ALT5";
        public const string Alt6CutsceneViewId = "ALT6";
        public const string Alt8CutsceneViewId = "ALT8";
        public const string Alt9CutsceneViewId = "ALT9";
        public const string Alt11CutsceneViewId = "ALT11";
        public const string Alt14CutsceneViewId = "ALT14";
        public const string Alt17CutsceneViewId = "ALT17";
        public const string Alt20CutsceneViewId = "ALT20";
        public const string Alt22CutsceneViewId = "ALT22";
        public const string ChimneyCrackHeardFlag = "CHIMNEY_CRACK_HEARD";
        public const string EavesdropCompleteFlag = "EAVESDROP_COMPLETE";
        public const string JamesWarnedFlag = "JAMES_WARNED";
        public const string ReadyToLeaveFlag = "READY_TO_LEAVE";
        public const string Scene1CompleteFlag = "SCENE1_COMPLETE";
        public const string Scene2StartedFlag = "SCENE2_STARTED";
        public const string MeetingCompleteFlag = "MEETING_COMPLETE";
        public const string Act3Scene1CompleteFlag = "ACT3_SCENE1_COMPLETE";
        public const string Act3Scene2WarningDeliveredFlag = "ACT3_SCENE2_WARNING_DELIVERED";
        public const string Act3Scene3CompleteFlag = "ACT3_SCENE3_COMPLETE";
        public const string Alt4SeenFlag = "ALT4_SEEN";
        public const string Alt5SeenFlag = "ALT5_SEEN";
        public const string Alt6SeenFlag = "ALT6_SEEN";
        public const string Alt8SeenFlag = "ALT8_SEEN";
        public const string Alt9SeenFlag = "ALT9_SEEN";
        public const string Alt11SeenFlag = "ALT11_SEEN";
        public const string Alt14SeenFlag = "ALT14_SEEN";
        public const string Alt17SeenFlag = "ALT17_SEEN";
        public const string Alt20SeenFlag = "ALT20_SEEN";
        public const string Alt22SeenFlag = "ALT22_SEEN";
        public const string ChimneyCrackHotspotId = "2N_CRACK_01";
        public const string ShawlHotspotId = "1E_SHAWL_01";
        public const string Node30KnockHotspotId = "30W_KNOCK_01";
        public const string Node30EnterHotspotId = "30W_ENTER_01";

        public static Dictionary<string, NodeViewData> Build()
        {
            return new Dictionary<string, NodeViewData>
            {
                ["1N"] = new NodeViewData
                {
                    viewId = "1N",
                    title = "1N - Bedroom Interior North View",
                    description = "James sleeps lightly. Every sound from below feels too loud.",
                    backgroundKey = "S01_N01_1N",
                    lightingMood = "Candlelight / Pre-dawn",
                    overlayColor = new Color(0.58f, 0.36f, 0.18f, 1f),
                    overlayOpacity = 0.12f,
                    autoLine = "The room is still, but the house below is not.",
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "1N_MED_01",
                            label = "Bandages & Medicine",
                            actionType = "Look",
                            responseText = "James's bandages are clean, but the wound has changed everything about this house."
                        },
                        new HotspotData
                        {
                            id = "1N_BIB_01",
                            label = "Bible / Cross",
                            actionType = "Look",
                            responseText = "A small sign of faith in a room filled with fear."
                        },
                        new HotspotData
                        {
                            id = "1N_WAT_01",
                            label = "Water Pitcher",
                            actionType = "Look",
                            responseText = "Water waits beside the bed. Even small comforts feel precious tonight."
                        },
                        new HotspotData
                        {
                            id = "1N_QUILT_01",
                            label = "Threadbare Quilt",
                            actionType = "Look",
                            responseText = "The quilt is thin at the edges. We have made it last through too many winters."
                        },
                        new HotspotData
                        {
                            id = "1N_LINEN_01",
                            label = "Reused Linen Strip",
                            actionType = "Look",
                            responseText = "A clean strip of linen waits nearby in case James's wound needs tending again."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "1W",
                        right = "1E",
                        back = "1S",
                        forward = string.Empty
                    }
                },

                ["1E"] = new NodeViewData
                {
                    viewId = "1E",
                    title = "1E - Wardrobe & Shawl",
                    description = "Ember glow catches the wardrobe and mending table.",
                    backgroundKey = "S01_N01_1E",
                    lightingMood = "Ember Glow",
                    overlayColor = new Color(0.45f, 0.22f, 0.16f, 1f),
                    overlayOpacity = 0.14f,
                    autoLine = "My shawl hangs ready, though I do not yet know how far I must carry it.",
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "1E_SHAWL_01",
                            label = "Shawl",
                            actionType = "Look",
                            responseText = "My shawl still holds the smell of wool smoke. It will have to do against the dawn chill."
                        },
                        new HotspotData
                        {
                            id = "1E_MEND_01",
                            label = "Mending Kit",
                            actionType = "Look",
                            responseText = "Needles, thread, and scraps of cloth. Even now, mending waits for no one."
                        },
                        new HotspotData
                        {
                            id = "1E_SHEET_01",
                            label = "Folded Poem/Music",
                            actionType = "Look",
                            responseText = "A folded sheet of verse and tune, saved from calmer evenings."
                        },
                        new HotspotData
                        {
                            id = "1E_COMB_01",
                            label = "Broken Comb",
                            actionType = "Look",
                            responseText = "The comb has missing teeth, but it is still useful enough to keep."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "1N",
                        right = "1S",
                        back = "1W",
                        forward = string.Empty
                    }
                },

                ["1S"] = new NodeViewData
                {
                    viewId = "1S",
                    title = "1S - Children's Wall & Keepsakes",
                    description = "The lamplight falls over drawings and little keepsakes.",
                    backgroundKey = "S01_N01_1S",
                    lightingMood = "Lamplight / Family Keepsakes",
                    overlayColor = new Color(0.40f, 0.28f, 0.20f, 1f),
                    overlayOpacity = 0.11f,
                    autoLine = "The children's things make the room feel smaller... and the danger larger.",
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "1W_DRAW_01",
                            label = "Children's Drawing",
                            actionType = "Look",
                            responseText = "Simple drawings of home and river. The children imagined safety in every line."
                        },
                        new HotspotData
                        {
                            id = "1W_BOX_01",
                            label = "Keepsake Box",
                            actionType = "Look",
                            responseText = "The keepsake box holds letters and tokens from years that felt less fragile."
                        },
                        new HotspotData
                        {
                            id = "1W_DOLL_01",
                            label = "Rag Doll",
                            actionType = "Look",
                            responseText = "A rag doll mended more than once, soft from being held every night."
                        },
                        new HotspotData
                        {
                            id = "1X_CANDLE_01",
                            label = "Candle Ends",
                            actionType = "Look",
                            responseText = "Short candle ends are saved for hard nights, and this is one of them."
                        },
                        new HotspotData
                        {
                            id = "1X_TEA_01",
                            label = "Empty Tea Tin",
                            actionType = "Look",
                            responseText = "The tea tin is empty, but no one throws away a useful tin in wartime."
                        },
                        new HotspotData
                        {
                            id = "1W_SOLES_01",
                            label = "Worn Shoes",
                            actionType = "Look",
                            responseText = "Worn shoes wait by the wall, ready for quiet steps before dawn."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "1E",
                        right = "1W",
                        back = "1N",
                        forward = string.Empty
                    }
                },

                ["1W"] = new NodeViewData
                {
                    viewId = "1W",
                    title = "1W - Bedroom Doorway",
                    description = "Warm shadow frames the doorway to the upstairs hall.",
                    backgroundKey = "S01_N01_1W",
                    lightingMood = "Doorway Shadow",
                    overlayColor = new Color(0.20f, 0.14f, 0.10f, 1f),
                    overlayOpacity = 0.22f,
                    autoLine = "The hallway waits in shadow. Below it, the soldiers move and speak.",
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "1S_LISTEN_01",
                            label = "Doorframe Listen",
                            actionType = "Listen",
                            responseText = "Voices rise faintly from below. American soldiers are still awake."
                        },
                        new HotspotData
                        {
                            id = "1S_SHOES_01",
                            label = "Children's Shoes",
                            actionType = "Look",
                            responseText = "The children's shoes are set near the threshold, toes toward the hall."
                        },
                        new HotspotData
                        {
                            id = "1S_POSY_01",
                            label = "Dried Posy",
                            actionType = "Look",
                            responseText = "A dried posy hangs by the frame, a reminder of gentler days."
                        },
                        new HotspotData
                        {
                            id = "1S_EXIT_01",
                            label = "Exit Prompt",
                            actionType = "Exit",
                            responseText = "The landing lies ahead. I need to move quietly.",
                            targetViewId = Node1ATopOfStairsViewId
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "1S",
                        right = "1N",
                        back = "1E",
                        forward = Node1ATopOfStairsViewId
                    }
                },

                // CORRECTED LANDING SPATIAL LOGIC:
                // From bedroom 1W, player enters 1A-S facing the stairs.
                // In 1A-S:
                // - Forward = downstairs to 3E
                // - Back = bedroom doorway / 1W
                // - Left = children's rooms / 1A-N
                // - Right = blank landing wall / placeholder
                // This prevents the children's rooms from appearing directly behind the bedroom exit.
                ["1A-S"] = new NodeViewData
                {
                    viewId = "1A-S",
                    title = "Top of Stairs",
                    description = "The stairwell falls away into shadow. Faint soldier voices rise from below.",
                    backgroundKey = "S01_N1A_1A-S",
                    autoLine = "The landing is colder than the bedroom. Below, the house no longer feels like ours.",
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "1A_S_STAIR_01",
                            label = "Stairwell Shadows",
                            actionType = "Look",
                            responseText = "The stairs carry every sound upward - boots, voices, and the uneasy weight of strangers below."
                        },
                        new HotspotData
                        {
                            id = "1A_S_CANDLE_01",
                            label = "Candle Stub",
                            actionType = "Look",
                            responseText = "A small candle stub burns low, barely enough to soften the landing's darkness."
                        },
                        new HotspotData
                        {
                            id = "1A_S_SEW_01",
                            label = "Sewing Basket",
                            actionType = "Look",
                            responseText = "The sewing basket sits where ordinary life was interrupted."
                        },
                        new HotspotData
                        {
                            id = "1A_S_RUM_01",
                            label = "Rum Smell",
                            actionType = "Look",
                            responseText = "The smell of rum rises faintly from below. The soldiers have made themselves too comfortable."
                        },
                        new HotspotData
                        {
                            id = "1A_S_EXIT_01",
                            label = "Exit Toward Hall",
                            actionType = "Exit",
                            responseText = "I have to move into the hall carefully.",
                            targetViewId = Node3FrontHallEntryViewId
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "1A-N",
                        right = "1A-W",
                        back = "1W",
                        forward = Node3FrontHallEntryViewId
                    }
                },

                // DESIGN NOTE:
                // 1A-N is the children's-room-facing landing view.
                // It is reached by turning left from 1A-S in the current gameplay layout.
                // The name is preserved for data compatibility, but the visual role is "children's rooms to the side of the landing."
                ["1A-N"] = new NodeViewData
                {
                    viewId = "1A-N",
                    title = "Toward Children's Rooms",
                    description = "A narrow passage leads toward the children's rooms. The doors are closed, and the house seems to hold its breath.",
                    backgroundKey = "S01_N1A_1A-N",
                    autoLine = "The children's rooms are quiet. Thank God.",
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "1A_N_KIDS_01",
                            label = "Children's Door",
                            actionType = "Look",
                            responseText = "The children sleep behind that door. Every choice tonight must protect them."
                        },
                        new HotspotData
                        {
                            id = "1A_N_TOY_01",
                            label = "Toy",
                            actionType = "Look",
                            responseText = "A small toy rests near the wall, forgotten in the confusion of occupation."
                        },
                        new HotspotData
                        {
                            id = "1A_N_FLOOR_01",
                            label = "Floorboard",
                            actionType = "Listen",
                            responseText = "The floorboard creaks softly. Too much noise could carry downstairs."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = string.Empty,
                        right = "1A-S",
                        back = "1A-S",
                        forward = string.Empty
                    }
                },

                ["1A-E"] = new NodeViewData
                {
                    viewId = "1A-E",
                    title = "Upstairs Landing — Blank Wall",
                    description = "A plain plaster wall catches the dim candle spill from the stairwell. Nothing useful lies this way.",
                    backgroundKey = "Upstairs Landing — Blank Wall",
                    autoLine = "Only plain plaster and dim spill light. Nothing useful lies this way.",
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "1A_WALL_01",
                            label = "Wall Plaster",
                            actionType = "Look",
                            responseText = "The wall is plain and cold to the touch. Every sound from below seems to climb through it."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "1A-S",
                        right = "1A-S",
                        back = "1A-S",
                        forward = string.Empty
                    }
                },

                ["1A-W"] = new NodeViewData
                {
                    viewId = "1A-W",
                    title = "Upstairs Landing — Blank Wall",
                    description = "A plain plaster wall catches the dim candle spill from the stairwell. Nothing useful lies this way.",
                    backgroundKey = "S01_N1A_1A-W",
                    lightingMood = "Dim landing light / stairwell shadow / candle spill",
                    autoLine = "Only plain plaster and dim spill light. Nothing useful lies this way.",
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "1A_WALL_01",
                            label = "Wall Plaster",
                            actionType = "Look",
                            responseText = "The wall is plain and cold to the touch. Every sound from below seems to climb through it."
                        },
                        new HotspotData
                        {
                            id = "1A_WALL_LIGHT_01",
                            label = "Lantern Spill",
                            actionType = "Look",
                            responseText = "The lantern glow barely reaches this side of the landing."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "1A-S",
                        right = "1A-S",
                        back = "1A-S",
                        forward = string.Empty
                    }
                },

                ["3E"] = new NodeViewData
                {
                    viewId = "3E",
                    title = "Front Hall — Coat Hooks & Window",
                    description = "The lower hall is cramped and tense. Officer gear hangs near the wall, and pale dawn presses against the window.",
                    backgroundKey = "S01_N03_3E",
                    autoLine = "The hall is narrow, but every object in it feels like evidence.",
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "3E_COAT_01",
                            label = "Officer's Coat",
                            actionType = "Look",
                            responseText = "An officer's coat hangs where family things should be. The occupation has reached even the walls."
                        },
                        new HotspotData
                        {
                            id = "3E_SACK_01",
                            label = "Haversack",
                            actionType = "Look",
                            responseText = "A military haversack. Maps, rations, and orders may have passed through hands like these."
                        },
                        new HotspotData
                        {
                            id = "3E_WINDOW_01",
                            label = "Window Smudges",
                            actionType = "Look",
                            responseText = "Smudges cloud the glass. Someone has been watching the road through this window."
                        },
                        new HotspotData
                        {
                            id = "3E_TABLE_01",
                            label = "Table with Rations",
                            actionType = "Look",
                            responseText = "Rations sit scattered across the table. The soldiers have eaten here as if the house were theirs."
                        },
                        new HotspotData
                        {
                            id = "3E_EXIT_01",
                            label = "Kitchen Exit",
                            actionType = "Exit",
                            responseText = "The kitchen doorway is open enough for me to slip through.",
                            targetViewId = Node2KitchenEntryViewId
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "3N",
                        right = "3S",
                        back = "3W",
                        forward = Node2KitchenEntryViewId
                    }
                },

                // Scene 1 Node 2 Kitchen:
                // 2N = Hearth & chimney / chimney crack unlock.
                // 2E = occupation evidence / mess tins / ration slip.
                // 2S = added rotational continuity view.
                // 2W = back door and fog / blocked hazard.
                // Kitchen returns to 3E front hall.
                // Do not allow exterior exit through 2W during Act I.
                ["2N"] = new NodeViewData
                {
                    viewId = "2N",
                    title = "Kitchen — Hearth & Chimney",
                    description = "The kitchen hearth glows low. The room smells of smoke, damp wood, and the soldiers' presence.",
                    backgroundKey = "S01_N02_2N",
                    autoLine = "The kitchen is quieter than the hall, but not safer.",
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "2N_HEARTH_01",
                            label = "Hearth",
                            actionType = "Look",
                            responseText = "The hearth still holds a little warmth, though the comfort of it feels stolen."
                        },
                        new HotspotData
                        {
                            id = "2N_HEARTH_02",
                            label = "Hearth Stones",
                            actionType = "Look",
                            responseText = "Ash settles in the cracks between hearth stones, still warm from the long night."
                        },
                        new HotspotData
                        {
                            id = "2N_KETTLE_01",
                            label = "Kettle",
                            actionType = "Look",
                            responseText = "The kettle sits near the fire, ordinary and fragile against the sounds from the next room."
                        },
                        new HotspotData
                        {
                            id = ChimneyCrackHotspotId,
                            label = "Chimney Crack",
                            actionType = "Listen",
                            responseText = "Through the chimney crack, the parlour voices sharpen. There is something important being said nearby.",
                            setsFlag = true,
                            flagName = ChimneyCrackHeardFlag,
                            flagValue = true
                        },
                        new HotspotData
                        {
                            id = "2N_CRACK_02",
                            label = "Chimney Crack (Shadow Line)",
                            actionType = "Listen",
                            responseText = "A second seam in the chimney carries fragments of parlour voices through the stone.",
                            setsFlag = true,
                            flagName = ChimneyCrackHeardFlag,
                            flagValue = true
                        },
                        new HotspotData
                        {
                            id = "2N_SHADOWS_01",
                            label = "Parlour Shadows",
                            actionType = "Look",
                            responseText = "Shadows shift faintly beyond the shared wall. The officers are close."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "2W",
                        right = "2E",
                        back = "2S",
                        forward = string.Empty
                    }
                },

                ["2E"] = new NodeViewData
                {
                    viewId = "2E",
                    title = "Kitchen — Mess Tins & Ration Slip",
                    description = "Military tins and scraps sit where family tools should be. The occupation has left its marks everywhere.",
                    backgroundKey = "S01_N02_2E",
                    autoLine = "Their things are everywhere. Every object says the same thing: this house is occupied.",
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "2E_TINS_01",
                            label = "Mess Tins",
                            actionType = "Look",
                            responseText = "Mess tins lie scattered across the work surface. The soldiers have eaten here without asking."
                        },
                        new HotspotData
                        {
                            id = "2E_CUP_01",
                            label = "Tin Cup",
                            actionType = "Look",
                            responseText = "A dented tin cup smells faintly of rum and old tea."
                        },
                        new HotspotData
                        {
                            id = "2E_CUP_02",
                            label = "Cup Ring",
                            actionType = "Look",
                            responseText = "A dark ring marks where another cup sat not long ago."
                        },
                        new HotspotData
                        {
                            id = "2E_RATION_01",
                            label = "Ration Slip",
                            actionType = "Look",
                            responseText = "A ration slip. Proof that the army counts what it takes, even when it gives nothing back."
                        },
                        new HotspotData
                        {
                            id = "2E_RATION_02",
                            label = "Folded Ration Stub",
                            actionType = "Look",
                            responseText = "A folded ration stub is tucked under a tin edge, carelessly left behind."
                        },
                        new HotspotData
                        {
                            id = "2E_CRUMBS_01",
                            label = "Crumbs",
                            actionType = "Look",
                            responseText = "Coarse crumbs are pressed into the table grain."
                        },
                        new HotspotData
                        {
                            id = "2E_HALL_01",
                            label = "Return to Hall",
                            actionType = "Exit",
                            responseText = "The front hall is still open to me from here.",
                            targetViewId = Node3FrontHallEntryViewId
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "2N",
                        right = "2S",
                        back = "2W",
                        forward = Node3FrontHallEntryViewId
                    }
                },

                ["2W"] = new NodeViewData
                {
                    viewId = "2W",
                    title = "Kitchen — Back Door & Fog",
                    description = "The back door is dimly outlined by foggy dawn light. Beyond it, the yard is watched.",
                    backgroundKey = "S01_N02_2W",
                    autoLine = "The back way is too dangerous. Not yet.",
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "2W_DOOR_01",
                            label = "Back Door",
                            actionType = "Exit",
                            responseText = "Too exposed. Soldiers are outside. Not this way."
                        },
                        new HotspotData
                        {
                            id = "2W_FOG_01",
                            label = "Fogged Window",
                            actionType = "Look",
                            responseText = "Fog presses against the glass. Shapes outside appear and vanish before they can be trusted."
                        },
                        new HotspotData
                        {
                            id = "2W_YARD_01",
                            label = "Yard Sounds",
                            actionType = "Listen",
                            responseText = "A low voice outside. Then a boot in wet grass. The yard is not safe."
                        },
                        new HotspotData
                        {
                            id = "2W_SOLDIERS_01",
                            label = "Distant Soldiers",
                            actionType = "Listen",
                            responseText = "Muted soldier voices drift in from beyond the fog-there is no safe opening out here."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "2S",
                        right = "2N",
                        back = "2E",
                        forward = string.Empty
                    }
                },

                ["2S"] = new NodeViewData
                {
                    viewId = "2S",
                    title = "Kitchen — South Sideboard View",
                    description = "A supporting south-facing kitchen angle for continuity around the room's sideboard and shelves.",
                    backgroundKey = "S01_N02_2S",
                    autoLine = "A quieter slice of the kitchen, where daily order has been unsettled.",
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "2S_SIDEBOARD_01",
                            label = "Sideboard",
                            actionType = "Look",
                            responseText = "The sideboard still holds household items, though a few things are clearly out of place."
                        },
                        new HotspotData
                        {
                            id = "2S_SHELVES_01",
                            label = "Shelves",
                            actionType = "Look",
                            responseText = "The shelves show signs of hurried handling, as if someone searched in poor light."
                        },
                        new HotspotData
                        {
                            id = "2S_DOORWAY_01",
                            label = "Doorway Edge",
                            actionType = "Look",
                            responseText = "From here, the doorway line keeps both the hall and back door in uneasy reach."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "2E",
                        right = "2W",
                        back = "2N",
                        forward = string.Empty
                    }
                },

                ["3N"] = new NodeViewData
                {
                    viewId = "3N",
                    title = "Front Hall — Stair and Wall",
                    description = "The base of the stairs sits in shadow. Above, the landing fades into darkness while the hall walls hold every whisper.",
                    backgroundKey = "S01_N03_3N",
                    autoLine = "The stair and wall narrow the hall into a tight, listening space.",
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "3N_STAIR_01",
                            label = "Stair Shadow",
                            actionType = "Look",
                            responseText = "The stairs climb back toward the landing, swallowed by darkness before the top."
                        },
                        new HotspotData
                        {
                            id = "3N_CREAK_01",
                            label = "Wall / Floor Creak",
                            actionType = "Listen",
                            responseText = "A small creak runs through wall and floorboard together, as if the whole hall is listening."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "3W",
                        right = "3E",
                        back = "3S",
                        forward = string.Empty
                    }
                },

                ["3S"] = new NodeViewData
                {
                    viewId = "3S",
                    title = "Front Hall — Parlour Side",
                    description = "The parlour lies nearby, too dangerous to enter openly. Low voices seem to gather behind the wall.",
                    backgroundKey = "S01_N03_3S",
                    autoLine = "Voices from the parlour pull at my attention, but I cannot risk the door.",
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "3S_PARLOUR_01",
                            label = "Parlour Side",
                            actionType = "Listen",
                            responseText = "The parlour side of the hall carries danger in every murmur and shifting board."
                        },
                        new HotspotData
                        {
                            id = "3S_VOICES_01",
                            label = "Door Crack / Low Voices",
                            actionType = "Listen",
                            responseText = "Voices murmur beyond the wall - not clear enough to understand from here."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "3E",
                        right = "3W",
                        back = "3N",
                        forward = string.Empty
                    }
                },

                ["3B-N"] = new NodeViewData
                {
                    viewId = "3B-N",
                    title = "Parlour Eavesdrop",
                    description = "A tight view through the chimney crack. Three silhouettes sit in the parlour beyond: Brownell, Parker, and Dunbar.",
                    backgroundKey = "S01_N03B_3B-N",
                    autoLine = "",
                    hotspots = new List<HotspotData>(),
                    navigation = new NavigationTargets
                    {
                        left = string.Empty,
                        right = string.Empty,
                        back = string.Empty,
                        forward = string.Empty
                    },
                    isCutscene = true,
                    dialogueLines = new List<DialogueLine>
                    {
                        new DialogueLine
                        {
                            id = "3B_BROWNELL_01",
                            speaker = "Brownell",
                            text = "Sit down, Parker. We bring them order, not ruin-though order rarely asks permission.",
                            portraitKey = "S01_N03B_P_BROWNELL"
                        },
                        new DialogueLine
                        {
                            id = "3B_PARKER_01",
                            speaker = "Parker",
                            text = "Order? These folk would hide a full militia under their beds if they could. Give 'em an inch and they bolt.",
                            portraitKey = "S01_N03B_P_PARKER"
                        },
                        new DialogueLine
                        {
                            id = "3B_DUNBAR_01",
                            speaker = "Dunbar",
                            text = "I joined to fight soldiers, sir... not frighten families.",
                            portraitKey = "S01_N03B_P_DUNBAR"
                        },
                        new DialogueLine
                        {
                            id = "3B_PARKER_02",
                            speaker = "Parker",
                            text = "Oh, hear the lad. Next you'll be saying we should give 'em back their chickens and bread knives.",
                            portraitKey = "S01_N03B_P_PARKER"
                        },
                        new DialogueLine
                        {
                            id = "3B_BROWNELL_02",
                            speaker = "Brownell",
                            text = "That's enough. The Colonel expects a clean report by midday. And we will give him one.",
                            portraitKey = "S01_N03B_P_BROWNELL"
                        },
                        new DialogueLine
                        {
                            id = "3B_PARKER_03",
                            speaker = "Parker",
                            text = "Clean report, sir? With powder damp, tents leaking, and half the men sleeping on their feet?",
                            portraitKey = "S01_N03B_P_PARKER"
                        },
                        new DialogueLine
                        {
                            id = "3B_BROWNELL_03",
                            speaker = "Brownell",
                            text = "Drunk or not, they will march when ordered. We move when the scouting parties return... likely at first light tomorrow. DeCew will not expect us so soon.",
                            portraitKey = "S01_N03B_P_BROWNELL"
                        },
                        new DialogueLine
                        {
                            id = "3B_DUNBAR_02",
                            speaker = "Dunbar",
                            text = "Sir... word from the scouts said movement near the woods by DeCew. Could be militia regrouping.",
                            portraitKey = "S01_N03B_P_DUNBAR"
                        },
                        new DialogueLine
                        {
                            id = "3B_PARKER_04",
                            speaker = "Parker",
                            text = "Militia? Ghost stories. Only movement out there is farmers hauling rubbish.",
                            portraitKey = "S01_N03B_P_PARKER"
                        }
                    },
                    cutsceneReturnViewId = Node2KitchenEntryViewId,
                    cutsceneCompleteFlagName = EavesdropCompleteFlag,
                    cutsceneCompleteMessage = "Laura has heard enough. James must be warned.",
                    cutsceneCompleteButtonLabel = "Return to Kitchen"
                },

                ["1N-WARN"] = new NodeViewData
                {
                    viewId = "1N-WARN",
                    title = "Warn James",
                    description = "",
                    backgroundKey = "Bedroom North View",
                    autoLine = "",
                    hotspots = new List<HotspotData>(),
                    navigation = new NavigationTargets
                    {
                        left = string.Empty,
                        right = string.Empty,
                        back = string.Empty,
                        forward = string.Empty
                    },
                    isCutscene = true,
                    dialogueLines = new List<DialogueLine>
                    {
                        new DialogueLine
                        {
                            id = "1N_WARN_LAURA_01",
                            speaker = "Laura",
                            text = "James... I heard them. The Americans mean to march on DeCew at first light."
                        },
                        new DialogueLine
                        {
                            id = "1N_WARN_JAMES_01",
                            speaker = "James",
                            text = "DeCew? Are you certain?"
                        },
                        new DialogueLine
                        {
                            id = "1N_WARN_LAURA_02",
                            speaker = "Laura",
                            text = "They spoke plainly. Scouts first, then the force behind them. They believe no warning can reach him in time."
                        },
                        new DialogueLine
                        {
                            id = "1N_WARN_JAMES_02",
                            speaker = "James",
                            text = "Then someone must carry it."
                        },
                        new DialogueLine
                        {
                            id = "1N_WARN_LAURA_03",
                            speaker = "Laura",
                            text = "I know."
                        },
                        new DialogueLine
                        {
                            id = "1N_WARN_JAMES_03",
                            speaker = "James",
                            text = "Laura... the road will be watched."
                        },
                        new DialogueLine
                        {
                            id = "1N_WARN_LAURA_04",
                            speaker = "Laura",
                            text = "Then I will not take the road."
                        },
                        new DialogueLine
                        {
                            id = "1N_WARN_JAMES_04",
                            speaker = "James",
                            text = "The courage I lack in body, you carry in spirit."
                        }
                    },
                    cutsceneReturnViewId = "1N",
                    cutsceneCompleteFlagName = JamesWarnedFlag,
                    cutsceneCompleteMessage = "The decision has been made. Laura must prepare to leave.",
                    cutsceneCompleteButtonLabel = "Continue"
                },

                ["4E"] = new NodeViewData
                {
                    viewId = "4E",
                    title = "Front Yard - Garden & Firewood",
                    description = "The yard is damp with predawn fog. The garden, woodpile, and tools sit in the pale light, ordinary things made strange by danger.",
                    backgroundKey = "Front Yard - Garden & Firewood",
                    autoLine = "No time for the garden. Stay to the path.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "4E_WOOD_01",
                            label = "Woodpile",
                            actionType = "Look",
                            responseText = "Split pine and ash wait beside the house - the kind of ordinary work that war has interrupted."
                        },
                        new HotspotData
                        {
                            id = "4E_TOOL_01",
                            label = "Tool Handle",
                            actionType = "Look",
                            responseText = "The tool handle is worn smooth. Iron tools were costly enough that families repaired them for years."
                        },
                        new HotspotData
                        {
                            id = "4E_GARDEN_01",
                            label = "Garden Path",
                            actionType = "Look",
                            responseText = "The garden path is wet with fog. No time for it now - the gate is the way out."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "4N",
                        right = "4S",
                        back = "4W",
                        forward = string.Empty
                    }
                },

                ["4N"] = new NodeViewData
                {
                    viewId = "4N",
                    title = "Front Yard - Front Gate",
                    description = "The front gate waits ahead, its latch dark with damp. Beyond it lies the road out of Queenston.",
                    backgroundKey = "Front Yard - Front Gate",
                    autoLine = "Gate ahead... keep moving.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "4N_LATCH_01",
                            label = "Gate Latch",
                            actionType = "Look",
                            responseText = "Simple iron latch - common along rural properties, forged by local smiths."
                        },
                        new HotspotData
                        {
                            id = "4N_SIL_01",
                            label = "Distant Silhouettes",
                            actionType = "Look",
                            responseText = "American pickets often stood in pairs, rotating their watch every hour."
                        },
                        new HotspotData
                        {
                            id = "4N_EXIT_01",
                            label = "Exit Through Gate",
                            actionType = "Exit",
                            responseText = "The gate opens to the road west.",
                            targetViewId = Node5EntryViewId
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "4W",
                        right = "4E",
                        back = "4S",
                        forward = Node5EntryViewId
                    }
                },

                ["4S"] = new NodeViewData
                {
                    viewId = "4S",
                    title = "Front Yard - House Facade",
                    description = "The Secord house stands behind me in the fog. Its walls hold James, the children, and the danger I am leaving behind.",
                    backgroundKey = "Front Yard - House Facade",
                    autoLine = "Don't look back. Forward only.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "4S_CLAP_01",
                            label = "Clapboards",
                            actionType = "Look",
                            responseText = "Homes were often clad in local softwood, easily weathered by river fog."
                        },
                        new HotspotData
                        {
                            id = "4S_WINDOW_01",
                            label = "Bedroom Window",
                            actionType = "Look",
                            responseText = "Somewhere above, James waits. I cannot look back for long."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "4E",
                        right = "4W",
                        back = "4N",
                        forward = string.Empty
                    }
                },

                ["4W"] = new NodeViewData
                {
                    viewId = "4W",
                    title = "Front Yard - Fence Toward Main Road",
                    description = "The fence runs toward the main road. Fog thickens that way, and movement stirs beyond the rails.",
                    backgroundKey = "Front Yard - Fence Toward Main Road",
                    autoLine = "West patrol... keep away from there.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "4W_RAIL_01",
                            label = "Fence Rail",
                            actionType = "Look",
                            responseText = "The fence rail is wet with fog. It leads too close to the watched road."
                        },
                        new HotspotData
                        {
                            id = "4W_MOVE_01",
                            label = "Distant Movement",
                            actionType = "Look",
                            responseText = "Something shifts in the fog. A lantern perhaps - or a musket catching the first light."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "4S",
                        right = "4N",
                        back = "4E",
                        forward = Alt4CutsceneViewId
                    }
                },

                ["ALT4"] = new NodeViewData
                {
                    viewId = "ALT4",
                    title = "Patrol on Main Road",
                    description = "",
                    backgroundKey = "Front Yard - Main Road Patrol",
                    autoLine = "",
                    hotspots = new List<HotspotData>(),
                    navigation = new NavigationTargets
                    {
                        left = string.Empty,
                        right = string.Empty,
                        back = string.Empty,
                        forward = string.Empty
                    },
                    isCutscene = true,
                    dialogueLines = new List<DialogueLine>
                    {
                        new DialogueLine
                        {
                            id = "ALT4_SOLDIER_01",
                            speaker = "Soldier",
                            text = "Hold. Thought I heard something at the fence."
                        },
                        new DialogueLine
                        {
                            id = "ALT4_SOLDIER_02",
                            speaker = "Soldier",
                            text = "Keep your eyes open - Brownell wants this road tight."
                        },
                        new DialogueLine
                        {
                            id = "ALT4_LAURA_01",
                            speaker = "Laura",
                            text = "Too close - God help me, back... back now!"
                        }
                    },
                    cutsceneReturnViewId = "4N",
                    cutsceneCompleteFlagName = Alt4SeenFlag,
                    cutsceneCompleteMessage = "American patrols controlled key roads around occupied Queenston. The safer path is not always the obvious road.",
                    cutsceneCompleteButtonLabel = "Return to Gate"
                },

                ["5N"] = new NodeViewData
                {
                    viewId = "5N",
                    title = "Burned Fences Street",
                    description = "The road ahead is edged with scorched fence rails and damp morning haze. The village still sleeps, but occupation has marked everything.",
                    backgroundKey = "Burned Fences Street — Road Ahead",
                    autoLine = "Stay to the road... keep your pace.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "5N_CHAR_01",
                            label = "Charred Fence",
                            actionType = "Look",
                            responseText = "Charred rails lean at odd angles. Fire has a way of making even familiar roads look foreign."
                        },
                        new HotspotData
                        {
                            id = "5N_BOOT_01",
                            label = "Boot Tracks",
                            actionType = "Look",
                            responseText = "Boot tracks cut through the damp dirt - too many to belong to neighbors."
                        },
                        new HotspotData
                        {
                            id = "5N_ROAD_01",
                            label = "Road Ahead",
                            actionType = "Look",
                            responseText = "The road narrows westward. It is the way forward, but not a place to linger."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "5W",
                        right = "5E",
                        back = "4N",
                        forward = Node6EntryViewId
                    }
                },

                ["5E"] = new NodeViewData
                {
                    viewId = "5E",
                    title = "Collapsed Fence",
                    description = "A fence has fallen inward beside the road. The earth is dark where smoke and rain have mixed.",
                    backgroundKey = "Burned Fences Street — Collapsed Fence",
                    autoLine = "Keep moving - don't linger.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "5E_BURN_01",
                            label = "Burn Pattern",
                            actionType = "Look",
                            responseText = "The burn pattern crawls along the wood grain. It started low, then ran fast through dry rails."
                        },
                        new HotspotData
                        {
                            id = "5E_RAIL_01",
                            label = "Broken Rail",
                            actionType = "Look",
                            responseText = "The rail is split where someone forced it down."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "5N",
                        right = "5S",
                        back = "5W",
                        forward = string.Empty
                    }
                },

                ["5S"] = new NodeViewData
                {
                    viewId = "5S",
                    title = "Village Homes",
                    description = "The houses behind and beside the road remain shuttered. No one wants to be seen watching.",
                    backgroundKey = "Burned Fences Street — Village Homes",
                    autoLine = "The village still sleeps... better that way.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "5S_SHUT_01",
                            label = "Shutter",
                            actionType = "Look",
                            responseText = "A shutter sits closed against the dawn. Families learn quickly when not to look out."
                        },
                        new HotspotData
                        {
                            id = "5S_DOOR_01",
                            label = "Quiet Doorway",
                            actionType = "Look",
                            responseText = "A doorway stands still in the haze. Quiet can be a kind of survival."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "5E",
                        right = "5W",
                        back = "5N",
                        forward = string.Empty
                    }
                },

                ["5W"] = new NodeViewData
                {
                    viewId = "5W",
                    title = "Smoke Column",
                    description = "A smoke column rises beyond the roadside, low and dark against the whitening sky. Movement flickers near it.",
                    backgroundKey = "Burned Fences Street — Smoke Column",
                    autoLine = "Don't go that way. Patrols may be close.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "5W_SMOKE_01",
                            label = "Smoke Column",
                            actionType = "Look",
                            responseText = "The smoke is too fresh. Someone is working near that burn pit."
                        },
                        new HotspotData
                        {
                            id = "5W_ASH_01",
                            label = "Ash Drift",
                            actionType = "Look",
                            responseText = "Fine ash drifts over the road edge, soft as dust and bitter in the throat."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "5S",
                        right = "5N",
                        back = "5E",
                        forward = Alt5CutsceneViewId
                    }
                },

                ["ALT5"] = new NodeViewData
                {
                    viewId = "ALT5",
                    title = "Smoke and Ash",
                    description = "",
                    backgroundKey = "Burned Fences Street — Smoke and Ash",
                    autoLine = "",
                    hotspots = new List<HotspotData>(),
                    navigation = new NavigationTargets
                    {
                        left = string.Empty,
                        right = string.Empty,
                        back = string.Empty,
                        forward = string.Empty
                    },
                    isCutscene = true,
                    dialogueLines = new List<DialogueLine>
                    {
                        new DialogueLine
                        {
                            id = "ALT5_SOLDIER_01",
                            speaker = "Soldier",
                            text = "Damn it - someone's been poking around here. Brownell wants this cleared!"
                        },
                        new DialogueLine
                        {
                            id = "ALT5_LAURA_01",
                            speaker = "Laura",
                            text = "They're right there... turn back, now!"
                        }
                    },
                    cutsceneReturnViewId = "5N",
                    cutsceneCompleteFlagName = Alt5SeenFlag,
                    cutsceneCompleteMessage = "Burn pits, requisition fires, and damaged fencing marked occupied settlements. Smoke could reveal soldiers before they were seen.",
                    cutsceneCompleteButtonLabel = "Return to Road"
                },

                ["6N"] = new NodeViewData
                {
                    viewId = "6N",
                    title = "Field Edge — Tree Line Fence",
                    description = "The last houses fall behind the haze. A rough fence line marks the edge between occupied village and open country.",
                    backgroundKey = "Field Edge — Tree Line Fence",
                    autoLine = "Stay in the open. Patrols prefer cover.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "6N_RAIL_01",
                            label = "Fence Rail",
                            actionType = "Look",
                            responseText = "The fence rail is damp with morning fog. Beyond it, the land opens westward."
                        },
                        new HotspotData
                        {
                            id = "6N_FIELD_01",
                            label = "Open Field",
                            actionType = "Look",
                            responseText = "The field looks exposed, but exposure may be safer than cover watched by patrols."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "6W",
                        right = "6E",
                        back = "5N",
                        forward = string.Empty
                    }
                },

                ["6W"] = new NodeViewData
                {
                    viewId = "6W",
                    title = "Field Edge Path",
                    description = "The path bends west along open farmland. Dew clings to the grass, and the village begins to fall away behind me.",
                    backgroundKey = "Field Edge — Path West",
                    autoLine = "The fields at last... keep to the path and stay low.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "6W_PATH_01",
                            label = "Footpath",
                            actionType = "Look",
                            responseText = "The footpath cuts through wet grass, narrow enough to vanish if I lose sight of it."
                        },
                        new HotspotData
                        {
                            id = "6W_DEW_01",
                            label = "Dew",
                            actionType = "Look",
                            responseText = "Dew wets the hem of my skirt. The day has barely begun, and already the road feels long."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "6S",
                        right = "6N",
                        back = "6E",
                        forward = Node7EntryViewId
                    }
                },

                ["6S"] = new NodeViewData
                {
                    viewId = "6S",
                    title = "Field Edge — Toward Village",
                    description = "Queenston lies behind in fog and pale smoke. The house is hidden now, but not forgotten.",
                    backgroundKey = "Field Edge — Village Behind",
                    autoLine = "Don't look back... too many eyes behind me.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "6S_HAZE_01",
                            label = "Village Haze",
                            actionType = "Look",
                            responseText = "The village haze swallows rooflines and roads alike. Distance is beginning to protect me."
                        },
                        new HotspotData
                        {
                            id = "6S_HOUSE_01",
                            label = "Distant House Line",
                            actionType = "Look",
                            responseText = "The houses blur together in the dawn. Somewhere among them, James waits."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "6E",
                        right = "6W",
                        back = "6N",
                        forward = string.Empty
                    }
                },

                ["6E"] = new NodeViewData
                {
                    viewId = "6E",
                    title = "Field Edge — Smoke Column Patrol",
                    description = "Smoke rises in the east, and something moves through the shimmer. The road is still too close.",
                    backgroundKey = "Field Edge — Smoke Column Patrol",
                    autoLine = "Something's moving through the shimmer... keep low - don't go that way.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "6E_SHIM_01",
                            label = "Heat Shimmer",
                            actionType = "Look",
                            responseText = "Early heat shimmer reveals movement before it reveals shapes. Something is there."
                        },
                        new HotspotData
                        {
                            id = "6E_SMOKE_01",
                            label = "Smoke Column",
                            actionType = "Look",
                            responseText = "The smoke column lifts unevenly. Someone has disturbed the fire below."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "6N",
                        right = "6S",
                        back = "6W",
                        forward = Alt6CutsceneViewId
                    }
                },

                ["ALT6"] = new NodeViewData
                {
                    viewId = "ALT6",
                    title = "Smoke Column Patrol Return",
                    description = "",
                    backgroundKey = "Field Edge — Smoke Column Patrol Return",
                    autoLine = "",
                    hotspots = new List<HotspotData>(),
                    navigation = new NavigationTargets
                    {
                        left = string.Empty,
                        right = string.Empty,
                        back = string.Empty,
                        forward = string.Empty
                    },
                    isCutscene = true,
                    dialogueLines = new List<DialogueLine>
                    {
                        new DialogueLine
                        {
                            id = "ALT6_LAURA_01",
                            speaker = "Laura",
                            text = "Something's moving through the shimmer..."
                        },
                        new DialogueLine
                        {
                            id = "ALT6_SOLDIER_01",
                            speaker = "Soldier",
                            text = "Checking the road again — tracks leading east."
                        },
                        new DialogueLine
                        {
                            id = "ALT6_SOLDIER_02",
                            speaker = "Soldier",
                            text = "Brownell wants this sweep finished before the men move."
                        },
                        new DialogueLine
                        {
                            id = "ALT6_LAURA_02",
                            speaker = "Laura",
                            text = "Too close. Stay low... back to the field."
                        }
                    },
                    cutsceneReturnViewId = "6N",
                    cutsceneCompleteFlagName = Alt6SeenFlag,
                    cutsceneCompleteMessage = "Returning patrols were dangerous because they crossed familiar ground unpredictably. Open fields could sometimes be safer than roads or cover.",
                    cutsceneCompleteButtonLabel = "Return to Field Edge"
                },

                ["7W"] = new NodeViewData
                {
                    viewId = "7W",
                    title = "Orchard Path",
                    description = "A narrow grassy path runs between old apple trees. Dew glitters on the lower branches, and bees drift between the blossoms.",
                    backgroundKey = "Orchard Path — Forward",
                    autoLine = "The orchard... quieter ground. Keep moving, the light is rising fast.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "7W_APPLE_01",
                            label = "Apple Branch",
                            actionType = "Look",
                            responseText = "Early Niagara orchards often mixed varieties — summer apples, russets, and crab apples for vinegar."
                        },
                        new HotspotData
                        {
                            id = "7W_DEW_01",
                            label = "Dew-Soaked Path",
                            actionType = "Look",
                            responseText = "Heavy morning dew could soak shoes through. Travelers often carried spare cloth to wrap their feet."
                        },
                        new HotspotData
                        {
                            id = "7W_BEES_01",
                            label = "Bees in Blossoms",
                            actionType = "Look",
                            responseText = "The bees work as if no war has touched the world."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "7S",
                        right = "7N",
                        back = "7E",
                        forward = Node8EntryViewId
                    }
                },

                ["7N"] = new NodeViewData
                {
                    viewId = "7N",
                    title = "Orchard Path — Rising Sun",
                    description = "Golden beams cut through the leaves. Petals drift through the warming air.",
                    backgroundKey = "Orchard Path — Rising Sun",
                    autoLine = "The sun burns through the orchard faster than open field. Warm already.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "7N_BARK_01",
                            label = "Tree Bark",
                            actionType = "Look",
                            responseText = "Orchards were planted close to homesteads so families could better watch for pests and weather damage."
                        },
                        new HotspotData
                        {
                            id = "7N_SUN_01",
                            label = "Sun Beams",
                            actionType = "Look",
                            responseText = "The sun burns through the orchard faster than I expected. The cool hour is already passing."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "7W",
                        right = "7E",
                        back = "7S",
                        forward = string.Empty
                    }
                },

                ["7E"] = new NodeViewData
                {
                    viewId = "7E",
                    title = "Orchard Path — Valley View",
                    description = "The land falls softly behind me. Mist hangs over the lower ground, hiding the village in pale haze.",
                    backgroundKey = "Orchard Path — Valley View",
                    autoLine = "The village sits somewhere beneath that haze now... too far back to help me, too close to forget.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "7E_MIST_01",
                            label = "Mist Layer",
                            actionType = "Look",
                            responseText = "The village sits somewhere beneath that haze now — too far back to help me, too close to forget."
                        },
                        new HotspotData
                        {
                            id = "7E_LOW_01",
                            label = "Lower Ground",
                            actionType = "Look",
                            responseText = "Low ground keeps fog longer. It hides roads, houses, and sometimes soldiers."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "7N",
                        right = "7S",
                        back = "7W",
                        forward = string.Empty
                    }
                },

                ["7S"] = new NodeViewData
                {
                    viewId = "7S",
                    title = "Orchard Path — Shaded Treeline",
                    description = "A darker edge of orchard and brush gathers to the south. Dew drips steadily from leaves into the grass.",
                    backgroundKey = "Orchard Path — Shaded Treeline",
                    autoLine = "Tempting shade... but best not step too far off the path.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "7S_UNDER_01",
                            label = "Dark Underbrush",
                            actionType = "Look",
                            responseText = "The shade is tempting, but underbrush can hide holes, roots, and movement."
                        },
                        new HotspotData
                        {
                            id = "7S_LEAVES_01",
                            label = "Dripping Leaves",
                            actionType = "Look",
                            responseText = "Every leaf seems to hold last night's rain. One wrong step could soak me through."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "7E",
                        right = "7W",
                        back = "7N",
                        forward = string.Empty
                    }
                },

                ["8W"] = new NodeViewData
                {
                    viewId = "8W",
                    title = "Creek Crossing",
                    description = "A shallow ford cuts across the path. Morning mist hovers above the slow water, and slick stones break the surface.",
                    backgroundKey = "Creek Crossing — Ford",
                    autoLine = "Easy now... the stones will be slick from last night's rain.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "8W_WATER_01",
                            label = "Water Surface",
                            actionType = "Look",
                            responseText = "The water moves slowly, cold from the night. Reflections make the depth harder to judge."
                        },
                        new HotspotData
                        {
                            id = "8W_STONES_01",
                            label = "Ford Stones",
                            actionType = "Look",
                            responseText = "The stones are slick from rain and mist. Each step needs care."
                        },
                        new HotspotData
                        {
                            id = "8W_MIST_01",
                            label = "Morning Mist",
                            actionType = "Look",
                            responseText = "Mist clings low over the creek, softening the banks and hiding the uneven ground."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "8S",
                        right = "8N",
                        back = "8E",
                        forward = Node9EntryViewId
                    }
                },

                ["8N"] = new NodeViewData
                {
                    viewId = "8N",
                    title = "Creek Crossing — Slippery Edge",
                    description = "The northern bank rises steeply beside the creek. Saturated earth slopes toward the water.",
                    backgroundKey = "Creek Crossing — Slippery Edge",
                    autoLine = "Too steep — one wrong foot and I'll be in the water.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "8N_MUD_01",
                            label = "Muddy Bank",
                            actionType = "Look",
                            responseText = "The mud is too soft. One careless step could slide straight into the creek."
                        },
                        new HotspotData
                        {
                            id = "8N_RUNOFF_01",
                            label = "Runoff Lines",
                            actionType = "Look",
                            responseText = "Thin trails of water cut down the bank where last night's rain drained into the creek."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "8W",
                        right = "8E",
                        back = "8S",
                        forward = Alt8CutsceneViewId
                    }
                },

                ["8E"] = new NodeViewData
                {
                    viewId = "8E",
                    title = "Creek Crossing — Back to Orchard",
                    description = "The orchard path lies behind, brighter now as the sun lifts through the branches.",
                    backgroundKey = "Creek Crossing — Back to Orchard",
                    autoLine = "No sense turning back — not with the sun rising and soldiers waking.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "8E_DEW_01",
                            label = "Dew on Path",
                            actionType = "Look",
                            responseText = "The orchard path still shines with dew, but turning back would only lose time."
                        },
                        new HotspotData
                        {
                            id = "8E_ROWS_01",
                            label = "Orchard Rows",
                            actionType = "Look",
                            responseText = "The rows of trees blur together in the mist behind me."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "8N",
                        right = "8S",
                        back = "8W",
                        forward = string.Empty
                    }
                },

                ["8S"] = new NodeViewData
                {
                    viewId = "8S",
                    title = "Creek Crossing — Shadowed Woods",
                    description = "Dark branches gather south of the creek. Roots tangle beneath the shade.",
                    backgroundKey = "Creek Crossing — Shadowed Woods",
                    autoLine = "Too dark. Better to stay where I can see the ground clearly.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "8S_ROOT_01",
                            label = "Root Tangle",
                            actionType = "Look",
                            responseText = "The roots twist over one another, dark and wet under the leaves."
                        },
                        new HotspotData
                        {
                            id = "8S_BRANCH_01",
                            label = "Low Branches",
                            actionType = "Look",
                            responseText = "The branches hang low enough to catch on cloth and hair."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "8E",
                        right = "8W",
                        back = "8N",
                        forward = string.Empty
                    }
                },

                ["ALT8"] = new NodeViewData
                {
                    viewId = "ALT8",
                    title = "Slip on Edge",
                    description = "",
                    backgroundKey = "Creek Crossing — Slip on Edge",
                    autoLine = "",
                    hotspots = new List<HotspotData>(),
                    navigation = new NavigationTargets
                    {
                        left = string.Empty,
                        right = string.Empty,
                        back = string.Empty,
                        forward = string.Empty
                    },
                    isCutscene = true,
                    dialogueLines = new List<DialogueLine>
                    {
                        new DialogueLine
                        {
                            id = "ALT8_LINE_01",
                            speaker = "Laura",
                            text = "Ah—! The bank's giving way—"
                        },
                        new DialogueLine
                        {
                            id = "ALT8_LINE_02",
                            speaker = "Laura",
                            text = "Steady... steady — don't go in all the way—"
                        },
                        new DialogueLine
                        {
                            id = "ALT8_LINE_03",
                            speaker = "Laura",
                            text = "Cold... God, that water is freezing — hold to the root!"
                        },
                        new DialogueLine
                        {
                            id = "ALT8_LINE_04",
                            speaker = "Laura",
                            text = "Easy... climb back up — just a moment more."
                        }
                    },
                    cutsceneReturnViewId = "8W",
                    cutsceneCompleteFlagName = Alt8SeenFlag,
                    cutsceneCompleteMessage = "Creek banks could become unstable after rain. Safe crossings depended on stones, roots, and slow footing.",
                    cutsceneCompleteButtonLabel = "Return to Safe Stones"
                },

                ["9W"] = new NodeViewData
                {
                    viewId = "9W",
                    title = "Forest Rise Path",
                    description = "The path climbs into denser woods. Ferns brush the trail edge, and the air feels warmer beneath the canopy.",
                    backgroundKey = "Forest Rise — Path Forward",
                    autoLine = "The climb begins... the forest holds the heat close. Keep steady.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "9W_FERN_01",
                            label = "Ferns",
                            actionType = "Look",
                            responseText = "Ferns crowd the lower path, soft enough to brush aside but thick enough to hide uneven ground."
                        },
                        new HotspotData
                        {
                            id = "9W_LIGHT_01",
                            label = "Light Shafts",
                            actionType = "Look",
                            responseText = "Light falls in narrow shafts through the canopy. The forest is closing in around the trail."
                        },
                        new HotspotData
                        {
                            id = "9W_RISE_01",
                            label = "Rising Path",
                            actionType = "Look",
                            responseText = "The ground rises steadily now. Every step asks more than the last."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "9S",
                        right = "9N",
                        back = "9E",
                        forward = Node10EntryViewId
                    }
                },

                ["9N"] = new NodeViewData
                {
                    viewId = "9N",
                    title = "Forest Rise — Sunlit Glade",
                    description = "A small glade opens north of the path. Sunlight falls warmly across grass and low brush.",
                    backgroundKey = "Forest Rise — Sunlit Glade",
                    autoLine = "A small clearing... tempting, but too open.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "9N_GLADE_01",
                            label = "Glade Grass",
                            actionType = "Look",
                            responseText = "The grass looks soft and inviting, but leaving the path would waste time and strength."
                        },
                        new HotspotData
                        {
                            id = "9N_LIGHT_01",
                            label = "Warm Light",
                            actionType = "Look",
                            responseText = "The light is beautiful, but it also means exposure. Better to stay moving."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "9W",
                        right = "9E",
                        back = "9S",
                        forward = string.Empty
                    }
                },

                ["9E"] = new NodeViewData
                {
                    viewId = "9E",
                    title = "Forest Rise — Brush Edge",
                    description = "The way behind drops toward the creek. Brush and reeds thicken where the lower ground gathers water.",
                    backgroundKey = "Forest Rise — Brush Edge",
                    autoLine = "The creek falls behind. There is no reason to return.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "9E_BRUSH_01",
                            label = "Brush Edge",
                            actionType = "Look",
                            responseText = "The brush grows thicker where the ground stays damp. It would slow every step."
                        },
                        new HotspotData
                        {
                            id = "9E_CREEK_01",
                            label = "Creek Sound",
                            actionType = "Listen",
                            responseText = "The creek is already fading behind me, replaced by the thicker hum of the forest."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "9N",
                        right = "9S",
                        back = "9W",
                        forward = string.Empty
                    }
                },

                ["9S"] = new NodeViewData
                {
                    viewId = "9S",
                    title = "Forest Rise — Shadowed Roots",
                    description = "Roots twist across the shadowed side of the trail. Dry leaves shift faintly beneath the underbrush.",
                    backgroundKey = "Forest Rise — Shadowed Roots",
                    autoLine = "Too much hidden under those leaves. Stay to the clearer path.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "9S_ROOT_01",
                            label = "Root Tangle",
                            actionType = "Look",
                            responseText = "The roots coil over one another in the shade. It would be easy to catch a foot here."
                        },
                        new HotspotData
                        {
                            id = "9S_RUSTLE_01",
                            label = "Leaf Rustle",
                            actionType = "Listen",
                            responseText = "Something small moves beneath the leaves. The sound is quick, then gone."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "9E",
                        right = "9W",
                        back = "9N",
                        forward = Alt9CutsceneViewId
                    }
                },

                ["ALT9"] = new NodeViewData
                {
                    viewId = "ALT9",
                    title = "Snake Startle",
                    description = "",
                    backgroundKey = "Forest Rise — Snake Startle",
                    autoLine = "",
                    hotspots = new List<HotspotData>(),
                    navigation = new NavigationTargets
                    {
                        left = string.Empty,
                        right = string.Empty,
                        back = string.Empty,
                        forward = string.Empty
                    },
                    isCutscene = true,
                    dialogueLines = new List<DialogueLine>
                    {
                        new DialogueLine
                        {
                            id = "ALT9_LINE_01",
                            speaker = "Laura",
                            text = "Ah—! Something moved under the leaves—"
                        },
                        new DialogueLine
                        {
                            id = "ALT9_LINE_02",
                            speaker = "Laura",
                            text = "Only a snake... only a snake. Breathe."
                        },
                        new DialogueLine
                        {
                            id = "ALT9_LINE_03",
                            speaker = "Laura",
                            text = "No harm done. But I cannot afford panic."
                        }
                    },
                    cutsceneReturnViewId = "9W",
                    cutsceneCompleteFlagName = Alt9SeenFlag,
                    cutsceneCompleteMessage = "Most local snakes were not dangerous, but a sudden rustle could startle a tired traveler into a misstep.",
                    cutsceneCompleteButtonLabel = "Return to Path"
                },

                ["10W"] = new NodeViewData
                {
                    viewId = "10W",
                    title = "Ridge Climb Path",
                    description = "A narrow ascending footpath climbs into the ridge slope. Ferns brush the trail edge, and roots cross the packed earth.",
                    backgroundKey = "Ridge Climb — Path Forward",
                    autoLine = "The ridge begins here... every step steeper than the last. Steady now.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "10W_ROOT_01",
                            label = "Exposed Root Line",
                            actionType = "Look",
                            responseText = "Roots like these clawed across ridge paths — strong footholds, but easy to catch a toe on when rushing."
                        },
                        new HotspotData
                        {
                            id = "10W_EARTH_01",
                            label = "Packed Earth Rise",
                            actionType = "Look",
                            responseText = "This ground has carried settlers and militia alike for years — worn by boots, wagons, and cattle drives."
                        },
                        new HotspotData
                        {
                            id = "10W_GRADE_01",
                            label = "Rising Grade",
                            actionType = "Look",
                            responseText = "The slope asks more from every step. This is where the easy ground ends."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "10S",
                        right = "10N",
                        back = "10E",
                        forward = Node11EntryViewId
                    }
                },

                ["10N"] = new NodeViewData
                {
                    viewId = "10N",
                    title = "Ridge Climb — Orchard Valley View",
                    description = "The orchard canopy lies below now, softened by morning mist. The village is farther still.",
                    backgroundKey = "Ridge Climb — Orchard Valley View",
                    autoLine = "The orchards already look far behind... and the village farther still.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "10N_MIST_01",
                            label = "Misty Descent",
                            actionType = "Look",
                            responseText = "Valley mist often clung to low ground through mid-morning — cool to breathe, heavy on the skin."
                        },
                        new HotspotData
                        {
                            id = "10N_ORCHARD_01",
                            label = "Orchard Below",
                            actionType = "Look",
                            responseText = "The orchard looks gentler from above than it felt beneath my feet."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "10W",
                        right = "10E",
                        back = "10S",
                        forward = string.Empty
                    }
                },

                ["10E"] = new NodeViewData
                {
                    viewId = "10E",
                    title = "Ridge Climb — Ridge Edge Brush",
                    description = "Dense brush crowds the ridge edge. Small wildflowers break through the green, but the drop behind them is unforgiving.",
                    backgroundKey = "Ridge Climb — Ridge Edge Brush",
                    autoLine = "Too close to the edge here... one slip would cost precious time.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "10E_BRUSH_01",
                            label = "Brush Cluster",
                            actionType = "Look",
                            responseText = "Dense ridge brush held water longer — soaking skirts and slowing travelers."
                        },
                        new HotspotData
                        {
                            id = "10E_DROP_01",
                            label = "Edge Drop",
                            actionType = "Look",
                            responseText = "The slope falls away behind the brush. Beautiful, but not safe."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "10N",
                        right = "10S",
                        back = "10W",
                        forward = string.Empty
                    }
                },

                ["10S"] = new NodeViewData
                {
                    viewId = "10S",
                    title = "Ridge Climb — Ridge Wall",
                    description = "Grey limestone shows through the side of the ridge. The stone holds the morning cool even as the air warms.",
                    backgroundKey = "Ridge Climb — Ridge Wall",
                    autoLine = "Stone from the escarpment itself... cool even in the morning heat.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "10S_LIME_01",
                            label = "Limestone Face",
                            actionType = "Look",
                            responseText = "These limestone shelves ran along much of the Niagara ridge — markers of ancient lake beds."
                        },
                        new HotspotData
                        {
                            id = "10S_GOUGE_01",
                            label = "Old Gouges",
                            actionType = "Look",
                            responseText = "Faint marks score the stone where wheels, tools, or passing loads once scraped the ridge wall."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "10E",
                        right = "10W",
                        back = "10N",
                        forward = string.Empty
                    }
                },

                ["11W"] = new NodeViewData
                {
                    viewId = "11W",
                    title = "Mid-Ridge Traverse — Narrow Trail",
                    description = "The path thins along the hillside. Ferns sway at knee height, and embedded stones break the packed earth.",
                    backgroundKey = "Mid-Ridge Traverse — Narrow Trail",
                    autoLine = "This trail thins here... careful, Laura. One misstep costs more than time.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "11W_STONE_01",
                            label = "Embedded Stone Step",
                            actionType = "Look",
                            responseText = "Steps like these lasted decades — pressed deep by settlers heading toward the ridge farms."
                        },
                        new HotspotData
                        {
                            id = "11W_FERN_01",
                            label = "Low Fern Sweep",
                            actionType = "Look",
                            responseText = "Ferns grew thickest where the ridge held water — soft to brush aside, but easy to hide loose stone beneath."
                        },
                        new HotspotData
                        {
                            id = "11W_TRACK_01",
                            label = "Narrow Track",
                            actionType = "Look",
                            responseText = "The trail is no wider than it needs to be. A careless step would cost more than time."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "11S",
                        right = "11N",
                        back = "11E",
                        forward = Node12EntryViewId
                    }
                },

                ["11N"] = new NodeViewData
                {
                    viewId = "11N",
                    title = "Mid-Ridge Traverse — Valley Hollow",
                    description = "A deep hollow opens below the ridge. Blue-green shadows ripple over the slope, and mist lingers in the cooler pockets.",
                    backgroundKey = "Mid-Ridge Traverse — Valley Hollow",
                    autoLine = "A deep hollow below... peaceful, but too far down to mean safety.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "11N_HOLLOW_01",
                            label = "Hollow Mist",
                            actionType = "Look",
                            responseText = "Mist lingered in ridge hollows long after sunrise — cool traps of damp air."
                        },
                        new HotspotData
                        {
                            id = "11N_DEEP_01",
                            label = "Deep Hollow",
                            actionType = "Look",
                            responseText = "Peaceful from here, but too far down to offer safety."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "11W",
                        right = "11E",
                        back = "11S",
                        forward = string.Empty
                    }
                },

                ["11E"] = new NodeViewData
                {
                    viewId = "11E",
                    title = "Mid-Ridge Traverse — Ridge Edge Slide",
                    description = "The eastern edge drops into dense cedar. Loose stones glint in the angled sun, and a faint slip-mark cuts the surface soil.",
                    backgroundKey = "Mid-Ridge Traverse — Ridge Edge Slide",
                    autoLine = "Too loose there... shale gives way without warning. Best stay clear.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "11E_SHALE_01",
                            label = "Loose Shale",
                            actionType = "Look",
                            responseText = "Thin shale layers snapped easily — dangerous for travelers carrying speed."
                        },
                        new HotspotData
                        {
                            id = "11E_SLIP_01",
                            label = "Slip Mark",
                            actionType = "Look",
                            responseText = "Something has already slid here. The mark runs down toward the trees."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "11N",
                        right = "11S",
                        back = "11W",
                        forward = Alt11CutsceneViewId
                    }
                },

                ["11S"] = new NodeViewData
                {
                    viewId = "11S",
                    title = "Mid-Ridge Traverse — Ridge Wall Outcrop",
                    description = "A jagged limestone outcrop rises close beside the path. Mineral streaks mark the stone where water once ran.",
                    backgroundKey = "Mid-Ridge Traverse — Ridge Wall Outcrop",
                    autoLine = "Stone rising close at my side... a small comfort on such narrow ground.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "11S_LIME_01",
                            label = "Limestone Cut",
                            actionType = "Look",
                            responseText = "Travelers widened ridge paths with simple chisels — one careful cut at a time."
                        },
                        new HotspotData
                        {
                            id = "11S_MINERAL_01",
                            label = "Mineral Wash",
                            actionType = "Look",
                            responseText = "Pale mineral streaks show where water has slowly found its way down the stone."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "11E",
                        right = "11W",
                        back = "11N",
                        forward = string.Empty
                    }
                },

                ["ALT11"] = new NodeViewData
                {
                    viewId = "ALT11",
                    title = "Lost Track Moment",
                    description = "",
                    backgroundKey = "Mid-Ridge Traverse — Lost Track Moment",
                    autoLine = "",
                    hotspots = new List<HotspotData>(),
                    navigation = new NavigationTargets
                    {
                        left = string.Empty,
                        right = string.Empty,
                        back = string.Empty,
                        forward = string.Empty
                    },
                    isCutscene = true,
                    dialogueLines = new List<DialogueLine>
                    {
                        new DialogueLine
                        {
                            id = "ALT11_LINE_01",
                            speaker = "Laura",
                            text = "Ah—! The ground's shifting—"
                        },
                        new DialogueLine
                        {
                            id = "ALT11_LINE_02",
                            speaker = "Laura",
                            text = "Steady — steady — don't slide, don't slide—"
                        },
                        new DialogueLine
                        {
                            id = "ALT11_LINE_03",
                            speaker = "Laura",
                            text = "Hold the branch — yes — pull back, carefully—"
                        },
                        new DialogueLine
                        {
                            id = "ALT11_LINE_04",
                            speaker = "Laura",
                            text = "Close... far too close. Watch every foothold."
                        }
                    },
                    cutsceneReturnViewId = "11W",
                    cutsceneCompleteFlagName = Alt11SeenFlag,
                    cutsceneCompleteMessage = "Loose shale was a frequent hazard along Niagara ridge paths; travelers could lose footing suddenly where thin layers broke away.",
                    cutsceneCompleteButtonLabel = "Return to Ridge Trail"
                },

                ["12W"] = new NodeViewData
                {
                    viewId = "12W",
                    title = "Upper Ridge Crest — Path Forward",
                    description = "The path levels near the crest. Brighter sky breaks through thinning canopy, and pale limestone fragments scatter across the dry soil.",
                    backgroundKey = "Upper Ridge Crest — Path Forward",
                    autoLine = "The crest... thank God. The air moves freer up here, even if the heat does not.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "12W_LIME_01",
                            label = "Limestone Scatter",
                            actionType = "Look",
                            responseText = "Limestone broke naturally along the crest. Settlers used fragments to mark small paths or property lines."
                        },
                        new HotspotData
                        {
                            id = "12W_SKY_01",
                            label = "Open Sky Break",
                            actionType = "Look",
                            responseText = "At the ridge top, even a small gap feels wide — clear sightlines for miles when the morning haze lifts."
                        },
                        new HotspotData
                        {
                            id = "12W_FARMLAND_01",
                            label = "Distant Farmland",
                            actionType = "Look",
                            responseText = "Farmland lies ahead somewhere beyond the trees. The ridge has given height, but not safety."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "12S",
                        right = "12N",
                        back = "12E",
                        forward = Node13EntryViewId
                    }
                },

                ["12N"] = new NodeViewData
                {
                    viewId = "12N",
                    title = "Upper Ridge Crest — Northern Escarpment",
                    description = "The northern slope rolls steeply downward. Deep forest bowls hold blue shadows between shelves of stone.",
                    backgroundKey = "Upper Ridge Crest — Northern Escarpment",
                    autoLine = "Northward the ridge falls fast... colder air rising from those deep pockets.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "12N_BOWL_01",
                            label = "Forest Bowl Shadow",
                            actionType = "Look",
                            responseText = "Shadows in the ridge bowls hid cool air well past noon — misleading, but welcome to weary travelers."
                        },
                        new HotspotData
                        {
                            id = "12N_DROP_01",
                            label = "Northern Drop",
                            actionType = "Look",
                            responseText = "The ridge falls quickly northward. A wrong descent would steal hours."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "12W",
                        right = "12E",
                        back = "12S",
                        forward = string.Empty
                    }
                },

                ["12E"] = new NodeViewData
                {
                    viewId = "12E",
                    title = "Upper Ridge Crest — Ridge Edge Overlook",
                    description = "The eastern edge drops sharply into clustered canopy. Broken stone and sparse brush catch harsh sunlight.",
                    backgroundKey = "Upper Ridge Crest — Ridge Edge Overlook",
                    autoLine = "Too exposed there. The view is wide, but so is the risk.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "12E_STONE_01",
                            label = "Broken Stone Edge",
                            actionType = "Look",
                            responseText = "The broken edge shows where weather has split the crest over years of frost, rain, and heat."
                        },
                        new HotspotData
                        {
                            id = "12E_DROP_01",
                            label = "Eastern Drop",
                            actionType = "Look",
                            responseText = "The drop is sudden enough to make the breath catch. Better to stay on the crest path."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "12N",
                        right = "12S",
                        back = "12W",
                        forward = string.Empty
                    }
                },

                ["12S"] = new NodeViewData
                {
                    viewId = "12S",
                    title = "Upper Ridge Crest — Stone and Brush",
                    description = "Dry brush gathers along the southern side of the crest. The stone underfoot is pale, hard, and warm from the rising sun.",
                    backgroundKey = "Upper Ridge Crest — Stone and Brush",
                    autoLine = "The crest gives space, but not rest. The sun is gaining strength.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "12S_BRUSH_01",
                            label = "Dry Brush",
                            actionType = "Look",
                            responseText = "Brush this dry could scratch, snag, and slow a traveler already losing strength."
                        },
                        new HotspotData
                        {
                            id = "12S_STONE_01",
                            label = "Warm Stone",
                            actionType = "Look",
                            responseText = "The stone holds the sun quickly. By noon, exposed rock will feel almost alive with heat."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "12E",
                        right = "12W",
                        back = "12N",
                        forward = string.Empty
                    }
                },

                ["13W"] = new NodeViewData
                {
                    viewId = "13W",
                    title = "Abandoned Homestead — Path",
                    description = "A narrow footpath descends from the ridge crest toward a sagging rail fence. Beyond it, an overgrown yard waits in the heat.",
                    backgroundKey = "Abandoned Homestead — Path Forward",
                    autoLine = "An old place… left to the grass and the heat. Whoever lived here is long gone.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "13W_STONE_01",
                            label = "Lane Stone",
                            actionType = "Look",
                            responseText = "Flat stones like this once marked simple lanes — guides for carts and travelers heading in from the ridge."
                        },
                        new HotspotData
                        {
                            id = "13W_FENCE_01",
                            label = "Overgrown Fence Line",
                            actionType = "Look",
                            responseText = "Grass and scrub have swallowed the fence. Only the top rails show where the yard once stood clear and tended."
                        },
                        new HotspotData
                        {
                            id = "13W_ROOF_01",
                            label = "Collapsed Roofline",
                            actionType = "Look",
                            responseText = "The collapsed roof barely rises above the scrub. Whoever lived here is long gone."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "13S",
                        right = "13N",
                        back = "13E",
                        forward = Node14EntryViewId
                    }
                },

                ["13N"] = new NodeViewData
                {
                    viewId = "13N",
                    title = "Abandoned Homestead — Ridge Behind",
                    description = "The ridge crest behind me stands higher now, trees along the top forming a dark line against the bright sky.",
                    backgroundKey = "Abandoned Homestead — Ridge Behind",
                    autoLine = "The ridge stands behind me like a wall now… no easy way back up if I turned.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "13N_CREST_01",
                            label = "Crest Silhouette",
                            actionType = "Look",
                            responseText = "From down here the ridge looks like a dark line drawn against the sky — hiding every path I just walked."
                        },
                        new HotspotData
                        {
                            id = "13N_HEIGHT_01",
                            label = "Ridge Height",
                            actionType = "Look",
                            responseText = "No easy way back up if I turned. The road behind is already harder than the road ahead."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "13W",
                        right = "13E",
                        back = "13S",
                        forward = string.Empty
                    }
                },

                ["13E"] = new NodeViewData
                {
                    viewId = "13E",
                    title = "Abandoned Homestead — Flanking Field",
                    description = "A narrow side field lies half-choked with weeds. Small piles of fieldstone sit near the property edge.",
                    backgroundKey = "Abandoned Homestead — Flanking Field",
                    autoLine = "Cleared stones from the field, stacked at the edges… someone fought hard with this land.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "13E_STONEPILE_01",
                            label = "Fieldstone Pile",
                            actionType = "Look",
                            responseText = "Farmers dragged stones to the margins season after season — small walls of effort against stubborn ground."
                        },
                        new HotspotData
                        {
                            id = "13E_WEEDS_01",
                            label = "Tall Weeds",
                            actionType = "Look",
                            responseText = "The weeds have taken the field back. It would be slow work crossing that way."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "13N",
                        right = "13S",
                        back = "13W",
                        forward = string.Empty
                    }
                },

                ["13S"] = new NodeViewData
                {
                    viewId = "13S",
                    title = "Abandoned Homestead — Wagon Ruts",
                    description = "Old ruts lead away from the homestead, nearly swallowed by grass. A broken fence post leans nearby.",
                    backgroundKey = "Abandoned Homestead — Wagon Ruts",
                    autoLine = "Once this track carried wagons… now it barely carries the memory of them.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "13S_RUT_01",
                            label = "Worn Rut",
                            actionType = "Look",
                            responseText = "Wagon ruts lingered long after farms were abandoned — etched lines of weight and repetition in the earth."
                        },
                        new HotspotData
                        {
                            id = "13S_POST_01",
                            label = "Broken Fence Post",
                            actionType = "Look",
                            responseText = "The post has rotted through at the base. Wind, weather, and time have done what fire did not."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "13E",
                        right = "13W",
                        back = "13N",
                        forward = string.Empty
                    }
                },

                ["14W"] = new NodeViewData
                {
                    viewId = "14W",
                    title = "Old Fire Ring",
                    description = "A crude ring of blackened fieldstones sits in the clearing. Pale ash scatters unevenly across cracked earth.",
                    backgroundKey = "Old Fire Ring — Clearing",
                    autoLine = "An old camp… long abandoned, yet somehow recent enough to remember company.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "14W_ASH_01",
                            label = "Ash Scatter",
                            actionType = "Look",
                            responseText = "Campfire ash could linger for weeks in dry weather. Militia patrols left such rings scattered along ridge routes."
                        },
                        new HotspotData
                        {
                            id = "14W_STONES_01",
                            label = "Blackened Stones",
                            actionType = "Look",
                            responseText = "Fieldstones darkened like this meant long, hot burns — wind patterns etched in soot."
                        },
                        new HotspotData
                        {
                            id = "14W_SHIMMER_01",
                            label = "Heat Shimmer",
                            actionType = "Look",
                            responseText = "The heat bends the air above the dry ground. Even stillness feels unstable here."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "14S",
                        right = "14N",
                        back = "14E",
                        forward = Node15EntryViewId
                    }
                },

                ["14N"] = new NodeViewData
                {
                    viewId = "14N",
                    title = "Old Fire Ring — Thinned Ash Patch",
                    description = "A thin layer of ash covers a shallow depression. Charcoal flecks scatter in erratic lines, and something faintly metallic glints beneath.",
                    backgroundKey = "Old Fire Ring — Thinned Ash Patch",
                    autoLine = "The ash is thinner here… something disturbed it. Best tread light.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "14N_CHAR_01",
                            label = "Charcoal Flecks",
                            actionType = "Look",
                            responseText = "Soldiers often buried spent shot, tins, or cartridge scrap under ashes before breaking camp."
                        },
                        new HotspotData
                        {
                            id = "14N_GLINT_01",
                            label = "Metallic Glint",
                            actionType = "Look",
                            responseText = "Something catches the light beneath the ash, but the ground around it looks wrong."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "14W",
                        right = "14E",
                        back = "14S",
                        forward = Alt14CutsceneViewId
                    }
                },

                ["14E"] = new NodeViewData
                {
                    viewId = "14E",
                    title = "Old Fire Ring — Homestead Behind",
                    description = "The abandoned cabin sits behind the clearing, wavering through heat haze and overgrown grass.",
                    backgroundKey = "Old Fire Ring — Homestead Behind",
                    autoLine = "Nothing left there worth finding… just heat and silence.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "14E_INSECT_01",
                            label = "Insects in Light",
                            actionType = "Look",
                            responseText = "Midday sun drew clouds of insects to open clearings. Most travelers hurried through them to avoid bites."
                        },
                        new HotspotData
                        {
                            id = "14E_CABIN_01",
                            label = "Cabin Silhouette",
                            actionType = "Look",
                            responseText = "The old cabin looks less like shelter now and more like a warning."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "14N",
                        right = "14S",
                        back = "14W",
                        forward = string.Empty
                    }
                },

                ["14S"] = new NodeViewData
                {
                    viewId = "14S",
                    title = "Old Fire Ring — Dense Trees",
                    description = "Tightly clustered trees form a pocket of deep shade. Dark soil beneath them holds faint impressions of booted feet.",
                    backgroundKey = "Old Fire Ring — Dense Trees",
                    autoLine = "Too dark and close… the sun left this pocket for good reason.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "14S_PRINT_01",
                            label = "Footprint Impressions",
                            actionType = "Look",
                            responseText = "Soft forest ground could hold prints long after patrols passed — heel-first marks of booted men."
                        },
                        new HotspotData
                        {
                            id = "14S_SHADE_01",
                            label = "Deep Shade",
                            actionType = "Look",
                            responseText = "The shade is cooler, but too close. Darkness hides as much as it shelters."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "14E",
                        right = "14W",
                        back = "14N",
                        forward = string.Empty
                    }
                },

                ["ALT14"] = new NodeViewData
                {
                    viewId = "ALT14",
                    title = "Hidden Heat Pocket",
                    description = string.Empty,
                    backgroundKey = "Old Fire Ring — Hidden Heat Pocket",
                    autoLine = string.Empty,
                    hotspots = new List<HotspotData>(),
                    navigation = new NavigationTargets
                    {
                        left = string.Empty,
                        right = string.Empty,
                        back = string.Empty,
                        forward = string.Empty
                    },
                    isCutscene = true,
                    dialogueLines = new List<DialogueLine>
                    {
                        new DialogueLine
                        {
                            id = "ALT14_LINE_01",
                            speaker = "Laura",
                            text = "Ah—! Heat — there’s still fire under this—"
                        },
                        new DialogueLine
                        {
                            id = "ALT14_LINE_02",
                            speaker = "Laura",
                            text = "A powder bag… left smoldering? God preserve—"
                        },
                        new DialogueLine
                        {
                            id = "ALT14_LINE_03",
                            speaker = "Laura",
                            text = "Step back — don’t breathe it in."
                        },
                        new DialogueLine
                        {
                            id = "ALT14_LINE_04",
                            speaker = "Laura",
                            text = "Careful now. Old ash can hide more danger than flame."
                        }
                    },
                    cutsceneReturnViewId = "14W",
                    cutsceneCompleteFlagName = Alt14SeenFlag,
                    cutsceneCompleteMessage = "Buried coals and ash pockets could remain hot long after a fire appeared dead. Travelers avoided disturbed ash where soldiers or patrols had recently camped.",
                    cutsceneCompleteButtonLabel = "Return to Fire Ring"
                },

                ["15W"] = new NodeViewData
                {
                    viewId = "15W",
                    title = "Swamp Edge Approach",
                    description = "The marsh edge swallows the dry path in dark mud and standing water. Reeds lean inward as the ground softens underfoot.",
                    backgroundKey = "Swamp Edge Approach — Forward",
                    autoLine = "The ground gives a little more with each step... this is where the marsh truly begins.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "15W_MUD_01",
                            label = "Soft Mud Lip",
                            actionType = "Look",
                            responseText = "The lip of the marsh looks thin and slick. One careless step would sink deeper than expected."
                        },
                        new HotspotData
                        {
                            id = "15W_REEDS_01",
                            label = "Leaning Reeds",
                            actionType = "Look",
                            responseText = "The reeds bow toward the waterlogged path like a warning to keep moving slowly."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "15S",
                        right = "15N",
                        back = "15E",
                        forward = Node16EntryViewId
                    }
                },

                ["15N"] = new NodeViewData
                {
                    viewId = "15N",
                    title = "Swamp Edge Approach — Reedline",
                    description = "A reedline shivers where shallow water pushes through. Insects hover in a constant whine above the stems.",
                    backgroundKey = "Swamp Edge Approach — Reedline",
                    autoLine = "The reedline trembles with hidden movement... better not stray from the track.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "15N_REEDS_01",
                            label = "Reedline Movement",
                            actionType = "Look",
                            responseText = "Movement in the reedline usually means marsh birds or muskrat, not danger worth chasing."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "15W",
                        right = "15E",
                        back = "15S",
                        forward = string.Empty
                    }
                },

                ["15E"] = new NodeViewData
                {
                    viewId = "15E",
                    title = "Swamp Edge Approach — Open Pocket",
                    description = "A shallow pocket of water reflects bright sky between mats of grass and floating algae.",
                    backgroundKey = "Swamp Edge Approach — Open Pocket",
                    autoLine = "Too much open water there... looks shallow until the ground gives way.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "15E_WATER_01",
                            label = "Water Pocket",
                            actionType = "Look",
                            responseText = "Open pockets like this hide soft bottoms that can trap a hurried step."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "15N",
                        right = "15S",
                        back = "15W",
                        forward = string.Empty
                    }
                },

                ["15S"] = new NodeViewData
                {
                    viewId = "15S",
                    title = "Swamp Edge Approach — Raised Margin",
                    description = "A slightly raised strip of grass offers momentary firmer footing before the marsh deepens again.",
                    backgroundKey = "Swamp Edge Approach — Raised Margin",
                    autoLine = "A narrow margin of firmer ground... not safe, just safer than the rest.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "15S_MARGIN_01",
                            label = "Raised Margin",
                            actionType = "Look",
                            responseText = "Travelers favored these raised margins to avoid deep suction mud."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "15E",
                        right = "15W",
                        back = "15N",
                        forward = string.Empty
                    }
                },

                ["16W"] = new NodeViewData
                {
                    viewId = "16W",
                    title = "Deep Marsh Crossing",
                    description = "The marsh closes around the path. Mud grips at every step, and reeds break the view into narrow strips of glare and green shadow.",
                    backgroundKey = "Deep Marsh — Forward",
                    autoLine = "Each step heavier than the last… the marsh means to hold me here if I’m not careful.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "16W_SUCTION_01",
                            label = "Suction Pocket",
                            actionType = "Look",
                            responseText = "Mud like this could take a shoe clean off if pulled too fast. Slow, twisting steps kept travelers upright."
                        },
                        new HotspotData
                        {
                            id = "16W_REEDBREAK_01",
                            label = "Reed Break",
                            actionType = "Look",
                            responseText = "Broken reeds marked where someone rushed through — dangerous in marsh, where haste easily earns a fall."
                        },
                        new HotspotData
                        {
                            id = "16W_MUD_01",
                            label = "Mud Surface",
                            actionType = "Look",
                            responseText = "The mud shines wet in places that look firm from a distance. The ground cannot be trusted here."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "16S",
                        right = "16N",
                        back = "16E",
                        forward = Node17EntryViewId
                    }
                },

                ["16N"] = new NodeViewData
                {
                    viewId = "16N",
                    title = "Deep Marsh — Reeds Pulling Apart",
                    description = "Tall reeds part slightly where slow water moves beneath them. Insect wings catch flashes of sun between the stalks.",
                    backgroundKey = "Deep Marsh — Reeds Pulling Apart",
                    autoLine = "Something’s shifting behind those reeds… wind wouldn’t move the water so. Best keep to the marked track.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "16N_MOV_01",
                            label = "Reed Movement",
                            actionType = "Look",
                            responseText = "Reed movement like that usually meant a muskrat or marsh bird — rarely a threat, but never worth chasing."
                        },
                        new HotspotData
                        {
                            id = "16N_INSECTS_01",
                            label = "Insect Glints",
                            actionType = "Look",
                            responseText = "Wings flash in the sun like tiny sparks. The swarm thickens wherever the water stands still."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "16W",
                        right = "16E",
                        back = "16S",
                        forward = string.Empty
                    }
                },

                ["16E"] = new NodeViewData
                {
                    viewId = "16E",
                    title = "Deep Marsh — Open Water Pocket",
                    description = "A clearer pool of water opens too wide to step over. Algae drifts slowly across the surface, hiding the depth beneath.",
                    backgroundKey = "Deep Marsh — Open Water Pocket",
                    autoLine = "Too deep there — one step and I’d be sunk to my waist.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "16E_ALGAE_01",
                            label = "Algae Swirl",
                            actionType = "Look",
                            responseText = "Algae drifted over deeper pockets. Marsh travelers learned never to trust green water."
                        },
                        new HotspotData
                        {
                            id = "16E_DEPTH_01",
                            label = "Water Depth",
                            actionType = "Look",
                            responseText = "The pool looks quiet, but there is no telling how deep the mud lies under it."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "16N",
                        right = "16S",
                        back = "16W",
                        forward = string.Empty
                    }
                },

                ["16S"] = new NodeViewData
                {
                    viewId = "16S",
                    title = "Deep Marsh — Shallow Margin",
                    description = "A slightly raised margin breaks the waterline. Tall grass returns in small clumps, offering brief signs of firmer earth.",
                    backgroundKey = "Deep Marsh — Shallow Margin",
                    autoLine = "A small mercy — ground here holds a little better.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "16S_GRASS_01",
                            label = "Dry Grass Tuft",
                            actionType = "Look",
                            responseText = "Grass tufted like this meant shallower earth beneath — signs of marginally safer footing along marsh edges."
                        },
                        new HotspotData
                        {
                            id = "16S_FIRM_01",
                            label = "Firmer Patch",
                            actionType = "Look",
                            responseText = "The patch holds better than the surrounding mud, but not well enough to leave the track."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "16E",
                        right = "16W",
                        back = "16N",
                        forward = string.Empty
                    }
                },

                ["17W"] = new NodeViewData
                {
                    viewId = "17W",
                    title = "Collapsed Corduroy Road",
                    description = "Old logs lie across the marsh, half-sunk and slick with water. The road still exists, but only barely.",
                    backgroundKey = "Collapsed Corduroy — Forward",
                    autoLine = "The corduroy… God bless whoever built it, though time has nearly reclaimed every log.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "17W_LOG_01",
                            label = "Sunken Log Edge",
                            actionType = "Look",
                            responseText = "Logs like these were laid in haste decades ago — meant to rise above water, now swallowed whole."
                        },
                        new HotspotData
                        {
                            id = "17W_GAP_01",
                            label = "Gap Between Logs",
                            actionType = "Look",
                            responseText = "Gaps this wide meant a trapped foot — or worse — if the wrong log rolled beneath the weight."
                        },
                        new HotspotData
                        {
                            id = "17W_SLICK_01",
                            label = "Slick Wood Surface",
                            actionType = "Look",
                            responseText = "The wet wood shines in the glare. It may hold, or it may turn underfoot."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "17S",
                        right = "17N",
                        back = "17E",
                        forward = Node18EntryViewId
                    }
                },

                ["17N"] = new NodeViewData
                {
                    viewId = "17N",
                    title = "Collapsed Corduroy — Marsh Behind",
                    description = "The marsh trail behind disappears into reeds and water glare. Footprints fill slowly with muddy water.",
                    backgroundKey = "Collapsed Corduroy — Marsh Behind",
                    autoLine = "No returning that way — the marsh would eat time and strength both.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "17N_PRINT_01",
                            label = "Water-Filled Footprint",
                            actionType = "Look",
                            responseText = "Prints filling with water marked soil that could barely hold a fox, let alone a grown traveler."
                        },
                        new HotspotData
                        {
                            id = "17N_DRAGON_01",
                            label = "Dragonflies",
                            actionType = "Look",
                            responseText = "Dragonflies hover above the standing water, quick and bright against the heavy marsh air."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "17W",
                        right = "17E",
                        back = "17S",
                        forward = string.Empty
                    }
                },

                ["17E"] = new NodeViewData
                {
                    viewId = "17E",
                    title = "Collapsed Corduroy — Collapsed Edge",
                    description = "The corduroy breaks apart where logs have fallen inward. Water swirls around broken timbers.",
                    backgroundKey = "Collapsed Corduroy — Collapsed Edge",
                    autoLine = "Collapsed there… one step too far and I’d be in over my knees.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "17E_TIMBER_01",
                            label = "Rotting Timber",
                            actionType = "Look",
                            responseText = "Rotted corduroy timbers snapped under weight. This edge is too dangerous to cross."
                        },
                        new HotspotData
                        {
                            id = "17E_POOL_01",
                            label = "Dark Pool",
                            actionType = "Look",
                            responseText = "The water is dark enough to hide depth, mud, and broken wood below."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "17N",
                        right = "17S",
                        back = "17W",
                        forward = Alt17CutsceneViewId
                    }
                },

                ["17S"] = new NodeViewData
                {
                    viewId = "17S",
                    title = "Collapsed Corduroy — Side Reeds",
                    description = "Tall reeds close in beside a half-submerged fallen log. Insect clouds rise wherever the water is still.",
                    backgroundKey = "Collapsed Corduroy — Side Reeds",
                    autoLine = "Reeds closing in — no path through there but for animals that know the water’s depth.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "17S_LOG_01",
                            label = "Half-Submerged Log",
                            actionType = "Look",
                            responseText = "This log may have once been part of the corduroy, dragged loose by storms or spring floods."
                        },
                        new HotspotData
                        {
                            id = "17S_REEDS_01",
                            label = "Reed Wall",
                            actionType = "Look",
                            responseText = "Reeds closing this tightly leave no honest path through them."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "17E",
                        right = "17W",
                        back = "17N",
                        forward = string.Empty
                    }
                },

                ["ALT17"] = new NodeViewData
                {
                    viewId = "ALT17",
                    title = "Collapsed Corduroy Timber",
                    description = string.Empty,
                    backgroundKey = "Collapsed Corduroy — Collapsed Timber",
                    autoLine = string.Empty,
                    hotspots = new List<HotspotData>(),
                    navigation = new NavigationTargets
                    {
                        left = string.Empty,
                        right = string.Empty,
                        back = string.Empty,
                        forward = string.Empty
                    },
                    isCutscene = true,
                    dialogueLines = new List<DialogueLine>
                    {
                        new DialogueLine
                        {
                            id = "ALT17_LINE_01",
                            speaker = "Laura",
                            text = "The log’s moving—!"
                        },
                        new DialogueLine
                        {
                            id = "ALT17_LINE_02",
                            speaker = "Laura",
                            text = "My foot — it’s caught between the timbers—"
                        },
                        new DialogueLine
                        {
                            id = "ALT17_LINE_03",
                            speaker = "Laura",
                            text = "Slowly… don’t pull too fast. The mud will take the shoe."
                        },
                        new DialogueLine
                        {
                            id = "ALT17_LINE_04",
                            speaker = "Laura",
                            text = "There. Free. Back to the sound logs."
                        }
                    },
                    cutsceneReturnViewId = "17W",
                    cutsceneCompleteFlagName = Alt17SeenFlag,
                    cutsceneCompleteMessage = "Corduroy roads were made from logs laid across wet ground. As they rotted, gaps, rolling logs, and hidden mud made them hazardous.",
                    cutsceneCompleteButtonLabel = "Return to Corduroy Road"
                },

                ["18W"] = new NodeViewData
                {
                    viewId = "18W",
                    title = "Hidden Trail Entrance — Narrow Trail",
                    description = "A slim shaded footpath cuts through compact earth and flattened leaf litter. Mossy stones edge the trail beneath a tunnel of canopy.",
                    backgroundKey = "Hidden Trail Entrance — Narrow Trail",
                    autoLine = "Blessed shade… after the marsh, this trail feels like mercy itself.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "2:00–2:30 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "18W_MOSS_01",
                            label = "Moss Stones",
                            actionType = "Look",
                            responseText = "Moss marked this as a sheltered trail — cool and protected for years."
                        },
                        new HotspotData
                        {
                            id = "18W_CANOPY_01",
                            label = "Canopy Break",
                            actionType = "Look",
                            responseText = "Gaps in the canopy offered hints of sky — a promise of rising ground."
                        },
                        new HotspotData
                        {
                            id = "18W_LEAVES_01",
                            label = "Flattened Leaf Litter",
                            actionType = "Look",
                            responseText = "The leaves are pressed flat by earlier passage. Someone has used this path before."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "18S",
                        right = "18N",
                        back = "18E",
                        forward = Node19EntryViewId
                    }
                },

                ["18N"] = new NodeViewData
                {
                    viewId = "18N",
                    title = "Hidden Trail Entrance — Marsh Behind",
                    description = "Reeds are faintly visible through the trees. Haze still shimmers above the low marsh ground.",
                    backgroundKey = "Hidden Trail Entrance — Marsh Behind",
                    autoLine = "Hard to believe I walked that far… the marsh looks like another world already.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "2:00–2:30 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "18N_GLARE_01",
                            label = "Marsh Glare",
                            actionType = "Look",
                            responseText = "Hard to believe I walked that far. The marsh already looks like another world."
                        },
                        new HotspotData
                        {
                            id = "18N_REEDS_01",
                            label = "Reed Line",
                            actionType = "Look",
                            responseText = "The reed line hides the worst of the crossing, but not the memory of it."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "18W",
                        right = "18E",
                        back = "18S",
                        forward = string.Empty
                    }
                },

                ["18E"] = new NodeViewData
                {
                    viewId = "18E",
                    title = "Hidden Trail Entrance — Dense Undergrowth",
                    description = "Thick clusters of brush block the eastern side of the trail. No clear path continues through the tangle.",
                    backgroundKey = "Hidden Trail Entrance — Dense Undergrowth",
                    autoLine = "No way through that tangle.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "2:00–2:30 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "18E_ROOT_01",
                            label = "Root Cluster",
                            actionType = "Look",
                            responseText = "Roots grip the soil in knots. A skirt or ankle could catch there before I knew it."
                        },
                        new HotspotData
                        {
                            id = "18E_BRUSH_01",
                            label = "Tangled Brush",
                            actionType = "Look",
                            responseText = "The undergrowth is too thick to force through without noise or wasted strength."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "18N",
                        right = "18S",
                        back = "18W",
                        forward = string.Empty
                    }
                },

                ["18S"] = new NodeViewData
                {
                    viewId = "18S",
                    title = "Hidden Trail Entrance — Ridgeward Trees",
                    description = "Taller trees rise toward higher ground. Brighter beams cut through thinner canopy to the south.",
                    backgroundKey = "Hidden Trail Entrance — Ridgeward Trees",
                    autoLine = "Higher ground that way… but the trail leads west.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "2:00–2:30 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "18S_SCAR_01",
                            label = "Old Trunk Scar",
                            actionType = "Look",
                            responseText = "Old scars in tree bark could come from weather, tools, or travelers marking a remembered route."
                        },
                        new HotspotData
                        {
                            id = "18S_RISE_01",
                            label = "Higher Ground",
                            actionType = "Look",
                            responseText = "The land rises that way, but the hidden trail leads west."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "18E",
                        right = "18W",
                        back = "18N",
                        forward = string.Empty
                    }
                },

                ["19W"] = new NodeViewData
                {
                    viewId = "19W",
                    title = "Deep Hidden Trail — Forest Channel",
                    description = "A narrow dirt corridor winds through deep shade. Trees arch tightly overhead, and ferns brush the trail edges.",
                    backgroundKey = "Deep Hidden Trail — Forest Channel",
                    autoLine = "A true woodland path… hidden from the sun and the world beyond these trees.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "2:30–3:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "19W_ROOT_01",
                            label = "High Root Step",
                            actionType = "Look",
                            responseText = "Roots formed natural risers — useful for grip, but one misstep could twist an ankle."
                        },
                        new HotspotData
                        {
                            id = "19W_LIGHT_01",
                            label = "Filtered Light Band",
                            actionType = "Look",
                            responseText = "Light like this meant the canopy was thickening — forest deepening toward the trail’s secret end."
                        },
                        new HotspotData
                        {
                            id = "19W_FERN_01",
                            label = "Fern Edge",
                            actionType = "Look",
                            responseText = "The ferns close in along the trail, brushing cloth and hiding the exact edge of the path."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "19S",
                        right = "19N",
                        back = "19E",
                        forward = Node20EntryViewId
                    }
                },

                ["19N"] = new NodeViewData
                {
                    viewId = "19N",
                    title = "Deep Hidden Trail — Sloping Forest Rise",
                    description = "A gentle slope rises northward, coated in moss and crossed by thick roots.",
                    backgroundKey = "Deep Hidden Trail — Sloping Rise",
                    autoLine = "A cooler wind up that rise… but it’s not the trail I need.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "2:30–3:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "19N_MOSS_01",
                            label = "Moss Patch",
                            actionType = "Look",
                            responseText = "Moss of this thickness meant the ground stayed cool and damp even in summer heat."
                        },
                        new HotspotData
                        {
                            id = "19N_ROOTS_01",
                            label = "Rooted Incline",
                            actionType = "Look",
                            responseText = "The rise offers cooler air, but every root would slow me down."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "19W",
                        right = "19E",
                        back = "19S",
                        forward = string.Empty
                    }
                },

                ["19E"] = new NodeViewData
                {
                    viewId = "19E",
                    title = "Deep Hidden Trail — Tightened Undergrowth",
                    description = "Interwoven brush blocks the eastern side of the trail. Thin shafts of light reveal bramble thorns.",
                    backgroundKey = "Deep Hidden Trail — Tightened Undergrowth",
                    autoLine = "No going that way — not without tearing half my skirt apart.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "2:30–3:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "19E_BRAMBLE_01",
                            label = "Bramble Line",
                            actionType = "Look",
                            responseText = "Bramble like this tears cloth and skin alike. No path worth taking hides in there."
                        },
                        new HotspotData
                        {
                            id = "19E_THORN_01",
                            label = "Thorn Shafts",
                            actionType = "Look",
                            responseText = "The light catches the thorns just enough to warn me away."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "19N",
                        right = "19S",
                        back = "19W",
                        forward = string.Empty
                    }
                },

                ["19S"] = new NodeViewData
                {
                    viewId = "19S",
                    title = "Deep Hidden Trail — Ridge-Lateral Descent",
                    description = "The southern ground drops slightly, covered in dry leaves and angled shafts of light.",
                    backgroundKey = "Deep Hidden Trail — Ridge-Lateral Descent",
                    autoLine = "A drop that way… too easy to slip on the leaves.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "2:30–3:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "19S_LEAF_01",
                            label = "Dry Leaf Carpet",
                            actionType = "Look",
                            responseText = "Dry leaves can slide over packed soil like loose cloth. Easy to slip, easier to make noise."
                        },
                        new HotspotData
                        {
                            id = "19S_DROP_01",
                            label = "Southern Drop",
                            actionType = "Look",
                            responseText = "The descent looks minor, but tired feet misjudge small slopes."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "19E",
                        right = "19W",
                        back = "19N",
                        forward = string.Empty
                    }
                },

                ["20W"] = new NodeViewData
                {
                    viewId = "20W",
                    title = "Forest Clearing — Shaded Path",
                    description = "A soft clearing opens beneath tall hemlocks. Patchy grass lies flattened in places, and a narrow trail continues west into darker shade.",
                    backgroundKey = "Forest Clearing — Shaded Path",
                    autoLine = "A clearing… a welcome sight, though someone’s been here not long past.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "3:00–3:30 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "20W_GRASS_01",
                            label = "Flattened Grass",
                            actionType = "Look",
                            responseText = "Grass pressed like this meant a traveler rested here recently — too recent for comfort."
                        },
                        new HotspotData
                        {
                            id = "20W_TRL_01",
                            label = "Western Trail Opening",
                            actionType = "Look",
                            responseText = "The trail west is narrow, as though meant to be hidden from casual eyes."
                        },
                        new HotspotData
                        {
                            id = "20W_HEMLOCK_01",
                            label = "Hemlock Circle",
                            actionType = "Look",
                            responseText = "The hemlocks keep this clearing cool and dim, even in the late afternoon heat."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "20S",
                        right = "20N",
                        back = "20E",
                        forward = Node21EntryViewId
                    }
                },

                ["20N"] = new NodeViewData
                {
                    viewId = "20N",
                    title = "Forest Clearing — Canopy Gap",
                    description = "A single bright beam of afternoon light cuts into the clearing. Dust motes drift visibly through the air.",
                    backgroundKey = "Forest Clearing — Canopy Gap",
                    autoLine = "A rare break in the canopy… as if the forest watches but says nothing.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "3:00–3:30 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "20N_LIGHT_01",
                            label = "Light Column",
                            actionType = "Look",
                            responseText = "These light pockets appeared only where older trees finally fell — small scars of time in a deep forest."
                        },
                        new HotspotData
                        {
                            id = "20N_DUST_01",
                            label = "Dust Motes",
                            actionType = "Look",
                            responseText = "The dust turns slowly in the beam, making the stillness feel watched."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "20W",
                        right = "20E",
                        back = "20S",
                        forward = string.Empty
                    }
                },

                ["20E"] = new NodeViewData
                {
                    viewId = "20E",
                    title = "Forest Clearing — Abandoned Cook Fire",
                    description = "A small blackened fire circle sits half-buried in soil. A torn scrap of cloth catches on a low branch, and faint smoke dissolves into the air.",
                    backgroundKey = "Forest Clearing — Abandoned Cook Fire",
                    autoLine = "Someone camped here — recently enough the ground still holds their warmth.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "3:00–3:30 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "20E_CINDER_01",
                            label = "Warm Cinders",
                            actionType = "Look",
                            responseText = "Coals cooled slower under packed earth — sign of a fire no more than an hour old."
                        },
                        new HotspotData
                        {
                            id = "20E_CLOTH_01",
                            label = "Torn Cloth",
                            actionType = "Look",
                            responseText = "The cloth is caught low, where someone brushed past in haste."
                        },
                        new HotspotData
                        {
                            id = "20E_SMOKE_01",
                            label = "Smoke Thread",
                            actionType = "Look",
                            responseText = "The smoke is faint, but not gone. Someone left this place recently."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "20N",
                        right = "20S",
                        back = "20W",
                        forward = Alt20CutsceneViewId
                    }
                },

                ["20S"] = new NodeViewData
                {
                    viewId = "20S",
                    title = "Forest Clearing — Branch Pile",
                    description = "Low brush piles unnaturally at the clearing edge. Small branches lie cracked in a subtle arc.",
                    backgroundKey = "Forest Clearing — Branch Pile",
                    autoLine = "Strange… branches don’t fall in patterns like that by chance.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "3:00–3:30 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "20S_ARC_01",
                            label = "Branch Arc",
                            actionType = "Look",
                            responseText = "Some forest travelers left subtle signs for others — warnings or messages, depending on what followed."
                        },
                        new HotspotData
                        {
                            id = "20S_BRUSH_01",
                            label = "Low Brush",
                            actionType = "Look",
                            responseText = "The brush looks arranged, not merely fallen. Someone may have shaped this edge."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "20E",
                        right = "20W",
                        back = "20N",
                        forward = string.Empty
                    }
                },

                ["ALT20"] = new NodeViewData
                {
                    viewId = "ALT20",
                    title = "Abandoned Cook Fire",
                    description = string.Empty,
                    backgroundKey = "Forest Clearing — Abandoned Cook Fire",
                    autoLine = string.Empty,
                    hotspots = new List<HotspotData>(),
                    navigation = new NavigationTargets
                    {
                        left = string.Empty,
                        right = string.Empty,
                        back = string.Empty,
                        forward = string.Empty
                    },
                    isCutscene = true,
                    dialogueLines = new List<DialogueLine>
                    {
                        new DialogueLine
                        {
                            id = "ALT20_LINE_01",
                            speaker = "Laura",
                            text = "Still warm… someone was here not long ago."
                        },
                        new DialogueLine
                        {
                            id = "ALT20_LINE_02",
                            speaker = "Laura",
                            text = "Smoke under the ash — no, back from it."
                        },
                        new DialogueLine
                        {
                            id = "ALT20_LINE_03",
                            speaker = "Laura",
                            text = "If they return, I cannot be found standing over their fire."
                        },
                        new DialogueLine
                        {
                            id = "ALT20_LINE_04",
                            speaker = "Laura",
                            text = "Back to the clearing. Quietly."
                        }
                    },
                    cutsceneReturnViewId = "20W",
                    cutsceneCompleteFlagName = Alt20SeenFlag,
                    cutsceneCompleteMessage = "Fresh cook fires could reveal recent movement. In contested territory, a warm fire might mean soldiers, scouts, or travelers were nearby.",
                    cutsceneCompleteButtonLabel = "Return to Clearing"
                },

                ["21W"] = new NodeViewData
                {
                    viewId = "21W",
                    title = "Gully Overpass Approach — Ravine Rim Path",
                    description = "A narrow sloping path hugs the upper edge of a deep wooded ravine. Trees rise from below, their tops nearly level with the trail.",
                    backgroundKey = "Gully Overpass Approach — Ravine Rim Path",
                    autoLine = "The air cools here… the ravine below must be deep as it is dark.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "3:30–4:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "21W_DROP_01",
                            label = "Ravine Drop",
                            actionType = "Look",
                            responseText = "The gully plunged far below — trees grew upward as though reaching for the light from beneath."
                        },
                        new HotspotData
                        {
                            id = "21W_ROOT_01",
                            label = "Root Crossings",
                            actionType = "Look",
                            responseText = "Roots twisted across the path — good grip, but dangerous if caught at the edge."
                        },
                        new HotspotData
                        {
                            id = "21W_DUST_01",
                            label = "Dust in Light",
                            actionType = "Look",
                            responseText = "Afternoon sunlight catches dust and insects drifting across the drop."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "21S",
                        right = "21N",
                        back = "21E",
                        forward = Node22EntryViewId
                    }
                },

                ["21N"] = new NodeViewData
                {
                    viewId = "21N",
                    title = "Gully Overpass Approach — Higher Ridge",
                    description = "A steep rise climbs toward a higher crest. Dense trees climb with it, their canopy catching soft filtered light.",
                    backgroundKey = "Gully Overpass Approach — Higher Ridge",
                    autoLine = "The ridge rises sharply that way — too steep to climb now.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "3:30–4:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "21N_CANOPY_01",
                            label = "Upper Canopy Line",
                            actionType = "Look",
                            responseText = "The highest trees marked the crest — still far above this part of the ravine."
                        },
                        new HotspotData
                        {
                            id = "21N_RISE_01",
                            label = "Steep Rise",
                            actionType = "Look",
                            responseText = "The ridge rises sharply there. Too steep to climb now, and too costly in time."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "21W",
                        right = "21E",
                        back = "21S",
                        forward = string.Empty
                    }
                },

                ["21E"] = new NodeViewData
                {
                    viewId = "21E",
                    title = "Gully Overpass Approach — Deepening Ravine",
                    description = "The ravine slope falls sharply into darkness. Exposed roots hang over empty air, gripping thin soil.",
                    backgroundKey = "Gully Overpass Approach — Deepening Ravine",
                    autoLine = "Too steep… one wrong shift and the whole slope would carry me down.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "3:30–4:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "21E_ROOT_01",
                            label = "Hanging Roots",
                            actionType = "Look",
                            responseText = "Roots clung to thin soil here — trees holding desperately to the ravine’s edge."
                        },
                        new HotspotData
                        {
                            id = "21E_SHADOW_01",
                            label = "Shadowed Drop",
                            actionType = "Look",
                            responseText = "The bottom is hidden in shadow. Sound reaches it before sight does."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "21N",
                        right = "21S",
                        back = "21W",
                        forward = string.Empty
                    }
                },

                ["21S"] = new NodeViewData
                {
                    viewId = "21S",
                    title = "Gully Overpass Approach — Forested Shelf",
                    description = "A flatter shelf sits beneath large branches. Loam and pine needles soften the surface, and the air feels briefly still.",
                    backgroundKey = "Gully Overpass Approach — Forested Shelf",
                    autoLine = "A quiet shelf… but the trail stays to the west.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "3:30–4:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "21S_NEEDLE_01",
                            label = "Pine Needle Bed",
                            actionType = "Look",
                            responseText = "Pine needles softened steps here — muffling sound, hiding anyone who paused beneath the branches."
                        },
                        new HotspotData
                        {
                            id = "21S_SHELF_01",
                            label = "Quiet Shelf",
                            actionType = "Look",
                            responseText = "The shelf looks safer than the rim, but it does not lead forward."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "21E",
                        right = "21W",
                        back = "21N",
                        forward = string.Empty
                    }
                },

                ["22W"] = new NodeViewData
                {
                    viewId = "22W",
                    title = "Gully Overpass — Narrow Crossing",
                    description = "A thin strip of trail bridges two rises of ravine wall. Fallen trunk segments brace the edge, and afternoon light glows across the opposite slope.",
                    backgroundKey = "Gully Overpass — Narrow Crossing",
                    autoLine = "A narrow crossing… God keep my footing steady.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "4:00–4:30 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "22W_LOGS_01",
                            label = "Stabilizer Logs",
                            actionType = "Look",
                            responseText = "Logs placed this way meant someone passed not long ago — soldiers or scouts shoring the edge."
                        },
                        new HotspotData
                        {
                            id = "22W_SLOPE_01",
                            label = "Opposite Slope Light",
                            actionType = "Look",
                            responseText = "The far slope caught the lowering sun, its shadow stretching across the ravine like a warning."
                        },
                        new HotspotData
                        {
                            id = "22W_FOOTING_01",
                            label = "Narrow Footing",
                            actionType = "Look",
                            responseText = "The trail narrows here. One careless step would carry sound and stone into the gully below."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "22S",
                        right = "22N",
                        back = "22E",
                        forward = Node23EntryViewId
                    }
                },

                ["22N"] = new NodeViewData
                {
                    viewId = "22N",
                    title = "Gully Overpass — Rising Ravine Wall",
                    description = "A sharp wall of roots and rock angles upward. Thin vines trail down from the ridge above.",
                    backgroundKey = "Gully Overpass — Rising Ravine Wall",
                    autoLine = "Too steep — no path but this narrow bridge.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "4:00–4:30 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "22N_ROOT_01",
                            label = "Root Net",
                            actionType = "Look",
                            responseText = "The roots knit the slope together, but not enough to make a path."
                        },
                        new HotspotData
                        {
                            id = "22N_VINES_01",
                            label = "Hanging Vines",
                            actionType = "Look",
                            responseText = "The vines look strong until weight is put on them. Better not test them."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "22W",
                        right = "22E",
                        back = "22S",
                        forward = string.Empty
                    }
                },

                ["22E"] = new NodeViewData
                {
                    viewId = "22E",
                    title = "Gully Overpass — Overlook Drop",
                    description = "An exposed overlook juts toward the ravine. Boot tracks lead close to the edge, where crumbly soil falls away.",
                    backgroundKey = "Gully Overpass — Overlook Drop",
                    autoLine = "Tracks… soldiers have been here. God help me — stay clear of that edge.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "4:00–4:30 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "22E_TRACK_01",
                            label = "Boot Track",
                            actionType = "Look",
                            responseText = "Tracks… soldiers have been here. High ground gives sight over deep forest."
                        },
                        new HotspotData
                        {
                            id = "22E_EDGE_01",
                            label = "Crumbly Edge",
                            actionType = "Look",
                            responseText = "The soil is broken and loose. The overlook is not as solid as it looks."
                        },
                        new HotspotData
                        {
                            id = "22E_ECHO_01",
                            label = "Ravine Echo",
                            actionType = "Listen",
                            responseText = "Sound climbs strangely from below, then vanishes into the trees."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "22N",
                        right = "22S",
                        back = "22W",
                        forward = Alt22CutsceneViewId
                    }
                },

                ["22S"] = new NodeViewData
                {
                    viewId = "22S",
                    title = "Gully Overpass — Lower Shelf Overhang",
                    description = "A lower ridge shelf leans beneath slanted trees. Pine needles carpet the descent, making the ground look softer than it is.",
                    backgroundKey = "Gully Overpass — Lower Shelf Overhang",
                    autoLine = "Slopes too sharply — one slide and I’d vanish under the shelf.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "4:00–4:30 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "22S_NEEDLE_01",
                            label = "Needle Drift",
                            actionType = "Look",
                            responseText = "The needle layer could slide over hard soil beneath. A quiet surface is not always a safe one."
                        },
                        new HotspotData
                        {
                            id = "22S_DESCENT_01",
                            label = "Sloped Descent",
                            actionType = "Look",
                            responseText = "The shelf falls away too sharply. One slide and I could vanish beneath it."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "22E",
                        right = "22W",
                        back = "22N",
                        forward = string.Empty
                    }
                },

                ["ALT22"] = new NodeViewData
                {
                    viewId = "ALT22",
                    title = "American Patrol Overhead",
                    description = string.Empty,
                    backgroundKey = "Gully Overpass — Overlook Drop",
                    autoLine = string.Empty,
                    hotspots = new List<HotspotData>(),
                    navigation = new NavigationTargets
                    {
                        left = string.Empty,
                        right = string.Empty,
                        back = string.Empty,
                        forward = string.Empty
                    },
                    isCutscene = true,
                    dialogueLines = new List<DialogueLine>
                    {
                        new DialogueLine
                        {
                            id = "ALT22_LINE_01",
                            speaker = "Laura",
                            text = "Voices — American — right above me—"
                        },
                        new DialogueLine
                        {
                            id = "ALT22_LINE_02",
                            speaker = "Laura",
                            text = "Don’t breathe… don’t move…"
                        },
                        new DialogueLine
                        {
                            id = "ALT22_LINE_03",
                            speaker = "Laura",
                            text = "If they look down, it’s over—"
                        },
                        new DialogueLine
                        {
                            id = "ALT22_LINE_04",
                            speaker = "Laura",
                            text = "Back… back to the path — quiet now."
                        }
                    },
                    cutsceneReturnViewId = "22W",
                    cutsceneCompleteFlagName = Alt22SeenFlag,
                    cutsceneCompleteMessage = "American scouts patrolled ravine rims and ridge lines during the 1813 occupation. High ground allowed sight over deep forest.",
                    cutsceneCompleteButtonLabel = "Return to Overpass"
                },

                ["23W"] = new NodeViewData
                {
                    viewId = "23W",
                    title = "Western Ridge Exit — Upper Woodlands",
                    description = "The path broadens as it climbs out of ravine terrain. Taller, more widely spaced trees let the afternoon light through in warm bands.",
                    backgroundKey = "Western Ridge Exit — Upper Woodlands",
                    autoLine = "The forest opens… fields must lie somewhere beyond the rise.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "4:30–5:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "23W_CANOPY_01",
                            label = "Thinning Canopy",
                            actionType = "Look",
                            responseText = "Where the canopy broke apart, open land drew nearer — sunset light sharpening the gaps."
                        },
                        new HotspotData
                        {
                            id = "23W_LEAF_01",
                            label = "Dried Leaf Spread",
                            actionType = "Look",
                            responseText = "Dry leaves meant firmer ground. Travel past the ravine would be easier from here."
                        },
                        new HotspotData
                        {
                            id = "23W_AIR_01",
                            label = "Open Country Scent",
                            actionType = "Look",
                            responseText = "The air carries hints of open country ahead — grass, warm bark, and distance."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "23S",
                        right = "23N",
                        back = "23E",
                        forward = Node24EntryViewId
                    }
                },

                ["23N"] = new NodeViewData
                {
                    viewId = "23N",
                    title = "Western Ridge Exit — Upper Ridge Trees",
                    description = "Sturdy trunks climb toward a final ridge crest. Long shadows stretch beneath them in the lowering light.",
                    backgroundKey = "Western Ridge Exit — Upper Ridge Trees",
                    autoLine = "The ridge still rises to the north — but the trail bends west.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "4:30–5:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "23N_SHADOW_01",
                            label = "Shadow Rise",
                            actionType = "Look",
                            responseText = "The ridge still rises to the north, but the trail bends west."
                        },
                        new HotspotData
                        {
                            id = "23N_TRUNKS_01",
                            label = "Tall Trunks",
                            actionType = "Look",
                            responseText = "The trees stand wider apart here, letting the light travel farther between them."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "23W",
                        right = "23E",
                        back = "23S",
                        forward = string.Empty
                    }
                },

                ["23E"] = new NodeViewData
                {
                    viewId = "23E",
                    title = "Western Ridge Exit — Ravine Behind",
                    description = "The ravine drops away behind me. Dark pockets remain where the sun no longer touches.",
                    backgroundKey = "Western Ridge Exit — Ravine Behind",
                    autoLine = "The ravine is behind me now. I pray it stays that way.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "4:30–5:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "23E_DARK_01",
                            label = "Dark Ravine Pockets",
                            actionType = "Look",
                            responseText = "The deep ravine hides what it contains. I am glad to leave it behind."
                        },
                        new HotspotData
                        {
                            id = "23E_ECHO_01",
                            label = "Echoing Hollow",
                            actionType = "Listen",
                            responseText = "The hollow still carries faint sounds upward, then swallows them."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "23N",
                        right = "23S",
                        back = "23W",
                        forward = string.Empty
                    }
                },

                ["23S"] = new NodeViewData
                {
                    viewId = "23S",
                    title = "Western Ridge Exit — Lower Brush",
                    description = "Lower brush thins along the southern side of the trail. Open air moves through the trees more freely here.",
                    backgroundKey = "Western Ridge Exit — Lower Brush",
                    autoLine = "The air clears slightly here. Every breath feels earned.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "4:30–5:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "23S_AIR_01",
                            label = "Open-Air Draft",
                            actionType = "Look",
                            responseText = "The breeze feels different now — less trapped by ravine walls."
                        },
                        new HotspotData
                        {
                            id = "23S_BRUSH_01",
                            label = "Thinning Brush",
                            actionType = "Look",
                            responseText = "The brush thins in patches, but not enough to make a better path."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "23E",
                        right = "23W",
                        back = "23N",
                        forward = string.Empty
                    }
                },

                ["24W"] = new NodeViewData
                {
                    viewId = "24W",
                    title = "Western Rise — Slope Approach",
                    description = "A gentle downward slope leads into a wider woodland corridor. Tall trunks stand farther apart, letting late-day golden light streak across the trail.",
                    backgroundKey = "Western Rise — Slope Approach",
                    autoLine = "The woods open wider here… quieter than any place I’ve passed today.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "5:45–6:20 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "24W_BEAM_01",
                            label = "Golden Beam",
                            actionType = "Look",
                            responseText = "Evening light catches the dust in warm bands — nature’s lanterns guiding west."
                        },
                        new HotspotData
                        {
                            id = "24W_CLEAR_01",
                            label = "Cleared Underbrush",
                            actionType = "Look",
                            responseText = "Brush cleared in lines like these meant a path well-traveled, though not necessarily by settlers."
                        },
                        new HotspotData
                        {
                            id = "24W_RUSTLE_01",
                            label = "Distant Rustle",
                            actionType = "Listen",
                            responseText = "A faint rustle moves somewhere beyond the trail. Not close. Not careless."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "24S",
                        right = "24N",
                        back = "24E",
                        forward = Node25EntryViewId
                    }
                },

                ["24N"] = new NodeViewData
                {
                    viewId = "24N",
                    title = "Western Rise — Mid-Ridge Tree Line",
                    description = "Higher ground rises to the north, dotted with tall pines. Wind threads through the upper branches.",
                    backgroundKey = "Western Rise — Mid-Ridge Tree Line",
                    autoLine = "Wind from the north… carrying something sharp on it — sap, perhaps.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "5:45–6:20 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "24N_PINE_01",
                            label = "Pine Ridge Cluster",
                            actionType = "Look",
                            responseText = "The pines hold the wind above me, their tops moving while the lower forest remains still."
                        },
                        new HotspotData
                        {
                            id = "24N_SAP_01",
                            label = "Sap Scent",
                            actionType = "Look",
                            responseText = "The wind carries a sharp green scent — sap, perhaps, or freshly broken needles."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "24W",
                        right = "24E",
                        back = "24S",
                        forward = string.Empty
                    }
                },

                ["24E"] = new NodeViewData
                {
                    viewId = "24E",
                    title = "Western Rise — Ravine Behind",
                    description = "The thicker forest behind me darkens toward the ravine. Shadows lengthen quickly along the route I crossed.",
                    backgroundKey = "Western Rise — Ravine Behind",
                    autoLine = "The ravine lies far behind… but its shadow lingers in the trees.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "5:45–6:20 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "24E_SHADOW_01",
                            label = "Shadow Fold",
                            actionType = "Look",
                            responseText = "The ravine lies far behind, but its shadow lingers in the trees."
                        },
                        new HotspotData
                        {
                            id = "24E_TRAIL_01",
                            label = "Fading Trail",
                            actionType = "Look",
                            responseText = "The path behind is already losing detail in the late light."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "24N",
                        right = "24S",
                        back = "24W",
                        forward = string.Empty
                    }
                },

                ["24S"] = new NodeViewData
                {
                    viewId = "24S",
                    title = "Western Rise — Southern Thicket Edge",
                    description = "A thick cluster of brush and broadleaf trees gathers to the south. Warm light paints the leaves with a reddish edge.",
                    backgroundKey = "Western Rise — Southern Thicket Edge",
                    autoLine = "The thicket holds its own secrets… but not the path I need.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "5:45–6:20 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "24S_LEAF_01",
                            label = "Red-Tinted Leaves",
                            actionType = "Look",
                            responseText = "The lowering sun reddens the leaf edges, making the thicket look warmer than it feels."
                        },
                        new HotspotData
                        {
                            id = "24S_THICKET_01",
                            label = "Thicket Wall",
                            actionType = "Look",
                            responseText = "The thicket holds its own secrets, but not the path I need."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "24E",
                        right = "24W",
                        back = "24N",
                        forward = string.Empty
                    }
                },

                ["25W"] = new NodeViewData
                {
                    viewId = "25W",
                    title = "Forest Threshold — Narrowing Passage",
                    description = "A slim, darkening corridor forms between tall trees. The ground dips slightly before rising again toward a brighter crest.",
                    backgroundKey = "Forest Threshold — Narrowing Passage",
                    autoLine = "Something… someone… is near. Not hostile — watching. Waiting.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "6:20–7:10 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "25W_ARCH_01",
                            label = "Arching Branch Line",
                            actionType = "Look",
                            responseText = "Branches bent inward marked a tended path — shaped by hands, not just weather."
                        },
                        new HotspotData
                        {
                            id = "25W_SHIFT_01",
                            label = "Peripheral Shift",
                            actionType = "Look",
                            responseText = "A presence moved beyond the trees — not approaching, not fleeing. Observing."
                        },
                        new HotspotData
                        {
                            id = "25W_QUIET_01",
                            label = "Quiet Air",
                            actionType = "Listen",
                            responseText = "The birds have softened. The silence feels deliberate."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "25S",
                        right = "25N",
                        back = "25E",
                        forward = Node26EntryViewId
                    }
                },

                ["25N"] = new NodeViewData
                {
                    viewId = "25N",
                    title = "Forest Threshold — Ridge-Facing Line",
                    description = "Tall pines rise toward a northern ridge. Faded sunlight catches their upper limbs while the lower forest remains dim.",
                    backgroundKey = "Forest Threshold — Ridge-Facing Line",
                    autoLine = "The ridge stands quiet… but the path is not up there.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "6:20–7:10 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "25N_SWAY_01",
                            label = "High Branch Sway",
                            actionType = "Look",
                            responseText = "The upper branches move in the wind, but the forest floor stays strangely still."
                        },
                        new HotspotData
                        {
                            id = "25N_RIDGE_01",
                            label = "Northern Ridge",
                            actionType = "Look",
                            responseText = "The ridge stands quiet, but the path is not up there."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "25W",
                        right = "25E",
                        back = "25S",
                        forward = string.Empty
                    }
                },

                ["25E"] = new NodeViewData
                {
                    viewId = "25E",
                    title = "Forest Threshold — Corridor Behind",
                    description = "A long line of darkening trees stretches behind me. Amber daylight fades across the trunks.",
                    backgroundKey = "Forest Threshold — Corridor Behind",
                    autoLine = "Hard to imagine I crossed so much land today… the forest feels like a different world now.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "6:20–7:10 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "25E_GLOW_01",
                            label = "Twilight Glow",
                            actionType = "Look",
                            responseText = "Hard to imagine I crossed so much land today. The forest feels like another world now."
                        },
                        new HotspotData
                        {
                            id = "25E_TRAIL_01",
                            label = "Trail Behind",
                            actionType = "Look",
                            responseText = "The trail behind remains open, but the day no longer belongs to what is behind me."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "25N",
                        right = "25S",
                        back = "25W",
                        forward = string.Empty
                    }
                },

                ["25S"] = new NodeViewData
                {
                    viewId = "25S",
                    title = "Forest Threshold — Dense Brush Curtain",
                    description = "Heavy brush forms a natural barrier. Branches angle upward as if shaped intentionally.",
                    backgroundKey = "Forest Threshold — Dense Brush Curtain",
                    autoLine = "Brush thick as a wall… someone tended it, I’m sure of it.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "6:20–7:10 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "25S_PATTERN_01",
                            label = "Brush Pattern",
                            actionType = "Look",
                            responseText = "Brush thick as a wall… someone tended it, I’m sure of it."
                        },
                        new HotspotData
                        {
                            id = "25S_BRANCH_01",
                            label = "Angled Branches",
                            actionType = "Look",
                            responseText = "The branches do not lie randomly. They guide the eye away from what lies beyond."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "25E",
                        right = "25W",
                        back = "25N",
                        forward = string.Empty
                    }
                },

                ["26W"] = new NodeViewData
                {
                    viewId = "26W",
                    title = "First Sight — Figure in the Trees",
                    description = "The trail widens slightly into a soft clearing. A figure stands at a respectful distance between two tall pines — motionless, calm, observing.",
                    backgroundKey = "First Sight — Figure in the Trees",
                    autoLine = "Someone is there… waiting for me. Not hiding — simply present.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "7:10–8:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "26W_FIGURE_01",
                            label = "Distant Figure",
                            actionType = "Look",
                            responseText = "A lone figure stands between the pines — calm, steady, watching my approach."
                        },
                        new HotspotData
                        {
                            id = "26W_SMOKE_01",
                            label = "Drifting Smoke",
                            actionType = "Look",
                            responseText = "Woodsmoke is faint on the breeze. Someone has tended a fire nearby."
                        },
                        new HotspotData
                        {
                            id = "26W_CLEARING_01",
                            label = "Soft Clearing",
                            actionType = "Look",
                            responseText = "The clearing feels chosen rather than accidental — open enough to meet, sheltered enough to remain unseen."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "26S",
                        right = "26N",
                        back = "26E",
                        forward = Node27MeetingCutsceneViewId
                    }
                },

                ["26N"] = new NodeViewData
                {
                    viewId = "26N",
                    title = "First Sight — Pines Above",
                    description = "Tall pines rise over the ridge-facing side. Light threads through the needles as the evening wind shifts.",
                    backgroundKey = "First Sight — Pines Above",
                    autoLine = "The wind shifts northward… carrying calm with it.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "7:10–8:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "26N_SHADOW_01",
                            label = "Pine Shadow",
                            actionType = "Look",
                            responseText = "The pine shadows stretch long and narrow, making the clearing feel both open and guarded."
                        },
                        new HotspotData
                        {
                            id = "26N_WIND_01",
                            label = "Northward Wind",
                            actionType = "Listen",
                            responseText = "The wind shifts northward through the needles, carrying calm with it."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "26W",
                        right = "26E",
                        back = "26S",
                        forward = string.Empty
                    }
                },

                ["26E"] = new NodeViewData
                {
                    viewId = "26E",
                    title = "First Sight — Path Behind",
                    description = "Twilight gathers along the narrow woodland corridor behind me. Shadows lengthen across the trail I have just crossed.",
                    backgroundKey = "First Sight — Path Behind",
                    autoLine = "The path behind feels distant now… as though the day belongs to another life.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "7:10–8:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "26E_AMBER_01",
                            label = "Amber Trail",
                            actionType = "Look",
                            responseText = "The path behind feels distant now, as though the day belongs to another life."
                        },
                        new HotspotData
                        {
                            id = "26E_SHADOWS_01",
                            label = "Lengthening Shadows",
                            actionType = "Look",
                            responseText = "Each shadow seems longer than the last. There is no easy way to return."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "26N",
                        right = "26S",
                        back = "26W",
                        forward = string.Empty
                    }
                },

                ["26S"] = new NodeViewData
                {
                    viewId = "26S",
                    title = "First Sight — Brushbend Clearing Edge",
                    description = "Saplings and brush bend subtly around the clearing edge. A thin thread of smoke drifts through the gaps.",
                    backgroundKey = "First Sight — Brushbend Clearing Edge",
                    autoLine = "Someone tended that fire — close enough to scent, not close enough to see.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "7:10–8:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "26S_THREAD_01",
                            label = "Smoke Thread",
                            actionType = "Look",
                            responseText = "Someone tended that fire — close enough to scent, not close enough to see."
                        },
                        new HotspotData
                        {
                            id = "26S_SAPLINGS_01",
                            label = "Bent Saplings",
                            actionType = "Look",
                            responseText = "The saplings bend around the clearing as if the space has been used before."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "26E",
                        right = "26W",
                        back = "26N",
                        forward = string.Empty
                    }
                },

                ["27-MEET"] = new NodeViewData
                {
                    viewId = "27-MEET",
                    title = "Meeting and Escort — First Contact",
                    description = string.Empty,
                    backgroundKey = "Meeting and Escort — First Contact",
                    autoLine = string.Empty,
                    hotspots = new List<HotspotData>(),
                    navigation = new NavigationTargets
                    {
                        left = string.Empty,
                        right = string.Empty,
                        back = string.Empty,
                        forward = string.Empty
                    },
                    isCutscene = true,
                    dialogueLines = new List<DialogueLine>
                    {
                        new DialogueLine
                        {
                            id = "27_D01_WAHSENNIYO",
                            speaker = "Wahsenniyo",
                            text = "You have come far from the soldiers’ path."
                        },
                        new DialogueLine
                        {
                            id = "27_D02_LAURA",
                            speaker = "Laura",
                            text = "I mean no harm. I carry warning for DeCew House."
                        },
                        new DialogueLine
                        {
                            id = "27_D03_WAHSENNIYO",
                            speaker = "Wahsenniyo",
                            text = "You carry no deceit. Speak slowly — truth walks on quiet feet."
                        },
                        new DialogueLine
                        {
                            id = "27_D04_TAREN",
                            speaker = "Taren",
                            text = "Alone, near evening, from the soldiers’ road? Tell us why we should trust you."
                        },
                        new DialogueLine
                        {
                            id = "27_D05_LAURA",
                            speaker = "Laura",
                            text = "I heard American officers in my own home. They mean to march at dawn, with scouts ahead."
                        },
                        new DialogueLine
                        {
                            id = "27_D06_TAREN",
                            speaker = "Taren",
                            text = "Many frightened people hear many things."
                        },
                        new DialogueLine
                        {
                            id = "27_D07_LAURA",
                            speaker = "Laura",
                            text = "They named DeCew. They spoke of moving before he could expect them."
                        },
                        new DialogueLine
                        {
                            id = "27_D08_SATEKARIWATE",
                            speaker = "Satekariwate",
                            text = "The crows have stopped calling. The enemy moves nearby."
                        },
                        new DialogueLine
                        {
                            id = "27_D09_WAHSENNIYO",
                            speaker = "Wahsenniyo",
                            text = "Truth does not shout. It waits to be heard."
                        },
                        new DialogueLine
                        {
                            id = "27_D10_TAREN",
                            speaker = "Taren",
                            text = "Her fear is real. But fear alone does not make truth."
                        },
                        new DialogueLine
                        {
                            id = "27_D11_LAURA",
                            speaker = "Laura",
                            text = "I left my husband wounded and my children sleeping. I would not cross this land for a rumor."
                        },
                        new DialogueLine
                        {
                            id = "27_D12_WAHSENNIYO",
                            speaker = "Wahsenniyo",
                            text = "Her words carry weight. We take her forward."
                        },
                        new DialogueLine
                        {
                            id = "27_D13_TAREN",
                            speaker = "Taren",
                            text = "Then I watch the rear. If soldiers follow, they meet me first."
                        },
                        new DialogueLine
                        {
                            id = "27_D14_LAURA",
                            speaker = "Laura",
                            text = "I never thought… anyone would walk beside me tonight."
                        },
                        new DialogueLine
                        {
                            id = "27_D15_WAHSENNIYO",
                            speaker = "Wahsenniyo",
                            text = "Then walk with care. The forest has accepted your purpose."
                        }
                    },
                    cutsceneReturnViewId = Node27EntryViewId,
                    cutsceneCompleteFlagName = MeetingCompleteFlag,
                    cutsceneCompleteMessage = "The scouts move into formation. Laura is no longer alone.",
                    cutsceneCompleteButtonLabel = "Continue"
                },

                ["27W"] = new NodeViewData
                {
                    viewId = "27W",
                    title = "Meeting and Escort — Forward With the Scouts",
                    description = "The path ahead bends toward DeCew House. Wahsenniyo leads with calm certainty while the others fall into protective positions.",
                    backgroundKey = "Meeting and Escort — Forward With the Scouts",
                    autoLine = "With them beside me… the night feels less like a grave.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "8:00–8:45 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "27W_FORMATION_01",
                            label = "Scout Formation",
                            actionType = "Look",
                            responseText = "They move naturally into formation — front, flank, rear — guiding me without crowding me."
                        },
                        new HotspotData
                        {
                            id = "27W_PATH_01",
                            label = "Path to DeCew",
                            actionType = "Look",
                            responseText = "The path west feels different now. Still dangerous, but no longer empty."
                        },
                        new HotspotData
                        {
                            id = "27W_WAHSENNIYO_01",
                            label = "Wahsenniyo Ahead",
                            actionType = "Look",
                            responseText = "Wahsenniyo leads without hurry, as if listening to more than footsteps."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "27S",
                        right = "27N",
                        back = "27E",
                        forward = Node28EntryViewId
                    }
                },

                ["27N"] = new NodeViewData
                {
                    viewId = "27N",
                    title = "Meeting and Escort — Wahsenniyo Leading",
                    description = "Wahsenniyo stands slightly ahead near the northern line of trees, calm and attentive to the forest.",
                    backgroundKey = "Meeting and Escort — Wahsenniyo Leading",
                    autoLine = "Wahsenniyo leads as though the forest speaks plainly to him.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "8:00–8:45 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "27N_WAHSENNIYO_01",
                            label = "Wahsenniyo’s Bearing",
                            actionType = "Look",
                            responseText = "His calm is not softness. It is discipline — a practiced attention to land, sound, and truth."
                        },
                        new HotspotData
                        {
                            id = "27N_TREES_01",
                            label = "Northern Trees",
                            actionType = "Look",
                            responseText = "The trees hold the last of the evening light while the path below falls into shade."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "27W",
                        right = "27E",
                        back = "27S",
                        forward = string.Empty
                    }
                },

                ["27E"] = new NodeViewData
                {
                    viewId = "27E",
                    title = "Meeting and Escort — Satekariwate on the Flank",
                    description = "Satekariwate keeps to the eastern side, nearly silent, watching the line of trees where motion would appear first.",
                    backgroundKey = "Meeting and Escort — Satekariwate on the Flank",
                    autoLine = "He walks so quietly that even the leaves seem to make room.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "8:00–8:45 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "27E_FLANK_01",
                            label = "Silent Flank",
                            actionType = "Look",
                            responseText = "Flank scouts watched for threats before they reached the group. Silence was not absence — it was protection."
                        },
                        new HotspotData
                        {
                            id = "27E_SIGNAL_01",
                            label = "Satekariwate’s Signal",
                            actionType = "Look",
                            responseText = "A small hand movement passes almost invisibly between the scouts."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "27N",
                        right = "27S",
                        back = "27W",
                        forward = string.Empty
                    }
                },

                ["27S"] = new NodeViewData
                {
                    viewId = "27S",
                    title = "Meeting and Escort — Taren Guarding the Rear",
                    description = "The path behind darkens quickly. Taren watches it with wary focus, his posture still skeptical but protective.",
                    backgroundKey = "Meeting and Escort — Taren Guarding the Rear",
                    autoLine = "Taren watches the darkness with vigilance. His doubt has become duty.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "8:00–8:45 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "27S_TAREN_01",
                            label = "Taren Guarding",
                            actionType = "Look",
                            responseText = "Rear guards watched for movement or glints of metal from approaching patrols. Taren does not waste a glance."
                        },
                        new HotspotData
                        {
                            id = "27S_PATH_01",
                            label = "Darkening Path",
                            actionType = "Look",
                            responseText = "The way behind feels less like a route now and more like a closed door."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "27E",
                        right = "27W",
                        back = "27N",
                        forward = string.Empty
                    }
                },

                ["28W"] = new NodeViewData
                {
                    viewId = "28W",
                    title = "DeCew Approach — Final Forest Approach",
                    description = "The trees thin into a broad, open rise. Ahead, the first lantern glow of DeCew House flickers through brush.",
                    backgroundKey = "DeCew Approach — Final Forest Approach",
                    autoLine = "Lanterns… the house is close. My legs tremble, but the end is near.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "8:45–9:20 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "28W_LANTERN_01",
                            label = "Lantern Flicker",
                            actionType = "Look",
                            responseText = "Lanterns burned low to avoid detection — shielded so the Americans could not see them from the ridge."
                        },
                        new HotspotData
                        {
                            id = "28W_SCOUTS_01",
                            label = "Scout Formation",
                            actionType = "Look",
                            responseText = "The three scouts shift into a practiced pattern — front, flank, rear — guiding me safely to the house."
                        },
                        new HotspotData
                        {
                            id = "28W_GLOW_01",
                            label = "DeCew Glow",
                            actionType = "Look",
                            responseText = "The glow ahead is small, but after the miles behind me, it feels enormous."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "28S",
                        right = "28N",
                        back = "28E",
                        forward = Node29EntryViewId
                    }
                },

                ["28N"] = new NodeViewData
                {
                    viewId = "28N",
                    title = "DeCew Approach — High Ridge",
                    description = "The dark shape of the ridge rises in fading light. Taren glances upward, attentive and alert.",
                    backgroundKey = "DeCew Approach — High Ridge",
                    autoLine = "Taren watches the ridge… even now, the threat of patrols hasn’t passed.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "8:45–9:20 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "28N_RIDGE_01",
                            label = "Ridge Silhouette",
                            actionType = "Look",
                            responseText = "The ridge is only a silhouette now, but danger could still move along it."
                        },
                        new HotspotData
                        {
                            id = "28N_TAREN_01",
                            label = "Taren Watching",
                            actionType = "Look",
                            responseText = "Taren watches the high ground even now. Near safety is not safety."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "28W",
                        right = "28E",
                        back = "28S",
                        forward = string.Empty
                    }
                },

                ["28E"] = new NodeViewData
                {
                    viewId = "28E",
                    title = "DeCew Approach — Path Behind",
                    description = "The dense woods fade into shadow behind me. Satekariwate is barely visible, marked only by motion.",
                    backgroundKey = "DeCew Approach — Path Behind",
                    autoLine = "He barely makes a sound… even now guarding the flank.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "8:45–9:20 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "28E_SILENT_01",
                            label = "Silent Progress",
                            actionType = "Look",
                            responseText = "He barely makes a sound, even now guarding the flank."
                        },
                        new HotspotData
                        {
                            id = "28E_TRAIL_01",
                            label = "Shadowed Trail",
                            actionType = "Look",
                            responseText = "The trail behind has swallowed the day. Every mile feels impossible now that it is over."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "28N",
                        right = "28S",
                        back = "28W",
                        forward = string.Empty
                    }
                },

                ["28S"] = new NodeViewData
                {
                    viewId = "28S",
                    title = "DeCew Approach — Clearing Edge",
                    description = "The forest gives way toward broader grounds. Distant silhouettes of outbuildings wait beyond the clearing.",
                    backgroundKey = "DeCew Approach — Clearing Edge",
                    autoLine = "The grounds open southward… just beyond lies safety — and the officer who must hear me.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "8:45–9:20 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "28S_CLEARING_01",
                            label = "Clearing Threshold",
                            actionType = "Look",
                            responseText = "The grounds open southward. Just beyond lies safety — and the officer who must hear me."
                        },
                        new HotspotData
                        {
                            id = "28S_OUTBUILDINGS_01",
                            label = "Outbuilding Silhouettes",
                            actionType = "Look",
                            responseText = "Low structures stand against the fading sky. The outpost is real now, no longer only hope."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "28E",
                        right = "28W",
                        back = "28N",
                        forward = string.Empty
                    }
                },

                ["29W"] = new NodeViewData
                {
                    viewId = "29W",
                    title = "DeCew House — The Doorstep",
                    description = "The stone-and-timber silhouette of DeCew House emerges fully. A shielded lantern glows beside the entry while Wahsenniyo stands slightly ahead.",
                    backgroundKey = "DeCew House — The Doorstep",
                    autoLine = "This is it… the place where my words must change the night.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "9:20–9:45 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "29W_LANTERN_01",
                            label = "Door Lantern",
                            actionType = "Look",
                            responseText = "Lanterns at DeCew House were deliberately shaded — enough light to guide allies, not enough to betray the house to patrols."
                        },
                        new HotspotData
                        {
                            id = "29W_SCOUTS_01",
                            label = "Scout Stance",
                            actionType = "Look",
                            responseText = "Wahsenniyo stands prepared to speak; Taren watches the trees; Satekariwate is nowhere — and everywhere — at once."
                        },
                        new HotspotData
                        {
                            id = "29W_DOOR_01",
                            label = "DeCew Door",
                            actionType = "Look",
                            responseText = "The door is only steps away. All the miles have narrowed to this one threshold."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "29S",
                        right = "29N",
                        back = "29E",
                        forward = Node30EntryViewId
                    }
                },

                ["29N"] = new NodeViewData
                {
                    viewId = "29N",
                    title = "DeCew House — Upper Clearing",
                    description = "Taren stands guard near the darker northern tree line. His silhouette is full of vigilance and pride.",
                    backgroundKey = "DeCew House — Upper Clearing",
                    autoLine = "Taren’s stance… unwavering. He protects even now.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "9:20–9:45 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "29N_GUARD_01",
                            label = "Guarded Shadow",
                            actionType = "Look",
                            responseText = "Taren’s stance is unwavering. He protects even now, when the house is close."
                        },
                        new HotspotData
                        {
                            id = "29N_TREELINE_01",
                            label = "Northern Tree Line",
                            actionType = "Look",
                            responseText = "The northern trees hold deep shadow. Any patrol could vanish there before being seen."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "29W",
                        right = "29E",
                        back = "29S",
                        forward = string.Empty
                    }
                },

                ["29E"] = new NodeViewData
                {
                    viewId = "29E",
                    title = "DeCew House — Forest Edge Behind",
                    description = "The forest path lies behind, darkening quickly. Satekariwate is nearly invisible, marked only by a faint shift in the leaves.",
                    backgroundKey = "DeCew House — Forest Edge Behind",
                    autoLine = "He watches the flank even here… unseen, but never absent.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "9:20–9:45 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "29E_PRESENCE_01",
                            label = "Shadowed Presence",
                            actionType = "Look",
                            responseText = "He watches the flank even here — unseen, but never absent."
                        },
                        new HotspotData
                        {
                            id = "29E_PATH_01",
                            label = "Forest Path",
                            actionType = "Look",
                            responseText = "The path behind has done its work. It carried me here, but I cannot return to it now."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "29N",
                        right = "29S",
                        back = "29W",
                        forward = string.Empty
                    }
                },

                ["29S"] = new NodeViewData
                {
                    viewId = "29S",
                    title = "DeCew House — Side Grounds",
                    description = "A low fence line and small outbuilding silhouette sit in the muted lantern spill. A shuttered window glows faintly.",
                    backgroundKey = "DeCew House — Side Grounds",
                    autoLine = "Quiet here… too quiet. The garrison must already be inside.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "9:20–9:45 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "29S_WINDOW_01",
                            label = "Shuttered Window",
                            actionType = "Look",
                            responseText = "Quiet here… too quiet. The garrison must already be inside."
                        },
                        new HotspotData
                        {
                            id = "29S_OUTBUILDING_01",
                            label = "Outbuilding",
                            actionType = "Look",
                            responseText = "The outbuilding stands in shadow, useful enough to be watched, dark enough to hide movement."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "29E",
                        right = "29W",
                        back = "29N",
                        forward = string.Empty
                    }
                },

                ["30-THRESH"] = new NodeViewData
                {
                    viewId = "30-THRESH",
                    title = "DeCew House — Threshold",
                    description = string.Empty,
                    backgroundKey = "DeCew House — At the Door",
                    autoLine = string.Empty,
                    hotspots = new List<HotspotData>(),
                    navigation = new NavigationTargets
                    {
                        left = string.Empty,
                        right = string.Empty,
                        back = string.Empty,
                        forward = string.Empty
                    },
                    isCutscene = true,
                    dialogueLines = new List<DialogueLine>
                    {
                        new DialogueLine
                        {
                            id = "30W_CUT_01",
                            speaker = "Narration",
                            text = "The knock lands heavy against the door. For one breath, nothing moves."
                        },
                        new DialogueLine
                        {
                            id = "30W_CUT_02",
                            speaker = "Sergeant",
                            text = "Identify yourself — quickly!"
                        },
                        new DialogueLine
                        {
                            id = "30W_CUT_03",
                            speaker = "Laura",
                            text = "I bring warning… from Queenston. American troops are coming."
                        },
                        new DialogueLine
                        {
                            id = "30W_CUT_04",
                            speaker = "Narration",
                            text = "The sergeant signals another soldier. Whispers pass through the hall beyond."
                        },
                        new DialogueLine
                        {
                            id = "30W_CUT_05",
                            speaker = "Wahsenniyo",
                            text = "Her words are true. We stand with her."
                        },
                        new DialogueLine
                        {
                            id = "30W_CUT_06",
                            speaker = "Sergeant",
                            text = "Inside. At once."
                        }
                    },
                    cutsceneReturnViewId = Node30EntryViewId,
                    cutsceneCompleteFlagName = Act3Scene1CompleteFlag,
                    cutsceneCompleteMessage = "The door opens. Laura has reached DeCew House.",
                    cutsceneCompleteButtonLabel = "Continue"
                },

                ["30W"] = new NodeViewData
                {
                    viewId = "30W",
                    title = "DeCew House — At the Door",
                    description = "Laura stands before the heavy wooden door, lantern light framing the threshold. Wahsenniyo waits one pace behind, calm and steady.",
                    backgroundKey = "DeCew House — At the Door",
                    autoLine = "This is the moment… all the miles, all the fear, all the courage led me here.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "9:45–10:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "30W_LATCH_01",
                            label = "Iron Latch",
                            actionType = "Look",
                            responseText = "The iron latch catches the lantern light. It is only a latch, yet it feels like the weight of the whole night."
                        },
                        new HotspotData
                        {
                            id = "30W_DOORWOOD_01",
                            label = "Door Wood",
                            actionType = "Look",
                            responseText = "The wood is thick and dark, solid enough to hold out fear for one more moment."
                        },
                        new HotspotData
                        {
                            id = "30W_KNOCK_01",
                            label = "Knock at the Door",
                            actionType = "Interact",
                            responseText = "My hand trembles… but I must knock."
                        },
                        new HotspotData
                        {
                            id = "30W_ENTER_01",
                            label = "Enter DeCew House",
                            actionType = "Exit",
                            responseText = "The sergeant leads us inside.",
                            targetViewId = Node31EntryViewId
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "30S",
                        right = "30N",
                        back = "30E",
                        forward = string.Empty
                    }
                },

                ["30N"] = new NodeViewData
                {
                    viewId = "30N",
                    title = "DeCew House — Guard Position",
                    description = "Taren stands near the northern approach, still and alert, watching the perimeter while Laura faces the door.",
                    backgroundKey = "DeCew House — Guard Position",
                    autoLine = "Taren holds the rear without a word.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "9:45–10:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "30N_GUARD_01",
                            label = "Rear Guard",
                            actionType = "Look",
                            responseText = "Rear guards held the perimeter until officers acknowledged an ally’s approach."
                        },
                        new HotspotData
                        {
                            id = "30N_TAREN_01",
                            label = "Taren’s Vigilance",
                            actionType = "Look",
                            responseText = "Taren does not relax because the door is close. The night still has edges."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "30W",
                        right = "30E",
                        back = "30S",
                        forward = string.Empty
                    }
                },

                ["30E"] = new NodeViewData
                {
                    viewId = "30E",
                    title = "DeCew House — Forest Edge",
                    description = "The forest edge lies behind, dim and shifting. Satekariwate remains near it, almost invisible among the leaves.",
                    backgroundKey = "DeCew House — Forest Edge",
                    autoLine = "Satekariwate watches the woods as if the dark itself might speak.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "9:45–10:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "30E_FLANK_01",
                            label = "Flank Watch",
                            actionType = "Look",
                            responseText = "Flank scouts watched the woods even as parley began."
                        },
                        new HotspotData
                        {
                            id = "30E_SATEKARIWATE_01",
                            label = "Satekariwate’s Presence",
                            actionType = "Look",
                            responseText = "Only the faintest shift in the leaves marks where he stands."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "30N",
                        right = "30S",
                        back = "30W",
                        forward = string.Empty
                    }
                },

                ["30S"] = new NodeViewData
                {
                    viewId = "30S",
                    title = "DeCew House — Grounds and Outbuildings",
                    description = "Shapes of sheds, fences, and supply areas rest in the lantern spill. Somewhere nearby, a horse shifts in the dark.",
                    backgroundKey = "DeCew House — Grounds and Outbuildings",
                    autoLine = "The outbuildings sit quiet, but the house itself seems to listen.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "9:45–10:00 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "30S_SUPPLY_01",
                            label = "Supply Buildings",
                            actionType = "Look",
                            responseText = "Support buildings housed supplies and horses for messenger dispatch."
                        },
                        new HotspotData
                        {
                            id = "30S_HORSE_01",
                            label = "Horse Stamp",
                            actionType = "Listen",
                            responseText = "A horse stamps once in the dark, then settles."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "30E",
                        right = "30W",
                        back = "30N",
                        forward = string.Empty
                    }
                },

                ["31W"] = new NodeViewData
                {
                    viewId = "31W",
                    title = "DeCew House Interior — Inside the Threshold",
                    description = "A narrow hall glows in warm lamplight. A British sergeant steps aside after admitting Laura, while militia men turn sharply from a nearby map table.",
                    backgroundKey = "DeCew House Interior — Inside the Threshold",
                    autoLine = "The air inside is warm… tense… every face turned toward me.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = false,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:00–10:05 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "31W_LAMP_01",
                            label = "Lamp Shade",
                            actionType = "Look",
                            responseText = "Shaded lamps were used indoors to keep visibility low from outside forces."
                        },
                        new HotspotData
                        {
                            id = "31W_MAP_01",
                            label = "Map Table",
                            actionType = "Look",
                            responseText = "Maps marked with pins show positions of American encampments, scouting trails, and river crossings."
                        },
                        new HotspotData
                        {
                            id = "31W_MILITIA_01",
                            label = "Militia Men",
                            actionType = "Look",
                            responseText = "They look up sharply, not startled by my presence so much as by what my arrival might mean."
                        },
                        new HotspotData
                        {
                            id = "31W_WAHSENNIYO_01",
                            label = "Wahsenniyo Behind",
                            actionType = "Look",
                            responseText = "Wahsenniyo enters behind me, calm and composed. His presence gives weight to my words before I speak them."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "31S",
                        right = "31N",
                        back = "31E",
                        forward = Node32EntryViewId
                    }
                },

                ["31N"] = new NodeViewData
                {
                    viewId = "31N",
                    title = "DeCew House Interior — Officers’ Hallway",
                    description = "A partially open door reveals papers, satchels, and dim lamplight beyond. Someone works late inside.",
                    backgroundKey = "DeCew House Interior — Officers’ Hallway",
                    autoLine = "Someone works late in that room… perhaps the officer himself.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = false,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:00–10:05 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "31N_PAPER_01",
                            label = "Paper Stack",
                            actionType = "Look",
                            responseText = "Orders, maps, and loose papers crowd the room beyond. War leaves little space empty."
                        },
                        new HotspotData
                        {
                            id = "31N_DOOR_01",
                            label = "Dim Doorway",
                            actionType = "Look",
                            responseText = "The room beyond may hold the officer I came to warn."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "31W",
                        right = "31E",
                        back = "31S",
                        forward = string.Empty
                    }
                },

                ["31E"] = new NodeViewData
                {
                    viewId = "31E",
                    title = "DeCew House Interior — Front Door",
                    description = "The door stands closed behind me. Satekariwate’s silhouette is barely visible near the threshold, silent in the dim rim-light.",
                    backgroundKey = "DeCew House Interior — Front Door",
                    autoLine = "He guards the flank even indoors… silent as dusk.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = false,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:00–10:05 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "31E_WATCH_01",
                            label = "Shadow Watch",
                            actionType = "Look",
                            responseText = "He guards the flank even indoors — silent as dusk, still listening for danger."
                        },
                        new HotspotData
                        {
                            id = "31E_DOOR_01",
                            label = "Closed Door",
                            actionType = "Look",
                            responseText = "The door has closed on the long road behind me. What matters now is what I say next."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "31N",
                        right = "31S",
                        back = "31W",
                        forward = string.Empty
                    }
                },

                ["31S"] = new NodeViewData
                {
                    viewId = "31S",
                    title = "DeCew House Interior — Storage Room Side",
                    description = "Crates, barrels, and small shelves line the dim side space. A militia man checks supplies with quiet urgency.",
                    backgroundKey = "DeCew House Interior — Storage Room Side",
                    autoLine = "Supplies stacked tight — rations ready for sudden movement.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = false,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:00–10:05 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "31S_CRATE_01",
                            label = "Supply Crate",
                            actionType = "Look",
                            responseText = "Supplies are stacked tight — rations, powder, and tools ready for sudden movement."
                        },
                        new HotspotData
                        {
                            id = "31S_BARREL_01",
                            label = "Barrel Stack",
                            actionType = "Look",
                            responseText = "Everything here is placed for use, not comfort. This house is no longer only a house."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "31E",
                        right = "31W",
                        back = "31N",
                        forward = string.Empty
                    }
                },

                ["32W"] = new NodeViewData
                {
                    viewId = "32W",
                    title = "Officer’s Room — FitzGibbon’s Entry",
                    description = "A compact room is lit by two shaded oil lamps. Maps of the Niagara peninsula are pinned to the wall, and a militia clerk works at a side desk. Lieutenant James FitzGibbon enters from the far door, composed and sharply attentive.",
                    backgroundKey = "Officer’s Room — FitzGibbon’s Entry",
                    autoLine = "He looks at me — not past me. He knows something is wrong before I even speak.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = false,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:05–10:12 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "32W_MAP_01",
                            label = "Pinned War Map",
                            actionType = "Look",
                            responseText = "Positions marked in careful ink — ridges, river crossings, enemy encampments."
                        },
                        new HotspotData
                        {
                            id = "32W_LAMP_01",
                            label = "Lamp Shield",
                            actionType = "Look",
                            responseText = "Light shields prevented glow from reaching shutter gaps — vital during occupation."
                        },
                        new HotspotData
                        {
                            id = "32W_CLERK_01",
                            label = "Militia Clerk",
                            actionType = "Look",
                            responseText = "The clerk keeps his pen ready, as if he expects words to become orders at any moment."
                        },
                        new HotspotData
                        {
                            id = "32W_FITZGIBBON_01",
                            label = "FitzGibbon Entering",
                            actionType = "Look",
                            responseText = "He enters without flourish. His attention fixes on the warning before I have fully spoken it."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "32S",
                        right = "32N",
                        back = "32E",
                        forward = Node33WarningCutsceneViewId
                    }
                },

                ["32N"] = new NodeViewData
                {
                    viewId = "32N",
                    title = "Officer’s Room — FitzGibbon’s Approach",
                    description = "FitzGibbon steps closer, posture upright and attentive. His uniform is worn from field work, not parade-ground polish.",
                    backgroundKey = "Officer’s Room — FitzGibbon’s Approach",
                    autoLine = "His calm is not ease — it is readiness.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = false,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:05–10:12 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "32N_BEARING_01",
                            label = "Officer’s Bearing",
                            actionType = "Look",
                            responseText = "His calm is not ease. It is readiness."
                        },
                        new HotspotData
                        {
                            id = "32N_UNIFORM_01",
                            label = "Field-Worn Uniform",
                            actionType = "Look",
                            responseText = "The uniform shows field wear, not display. This is a working officer, not a ceremonial one."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "32W",
                        right = "32E",
                        back = "32S",
                        forward = string.Empty
                    }
                },

                ["32E"] = new NodeViewData
                {
                    viewId = "32E",
                    title = "Officer’s Room — Corner Shadows",
                    description = "Only the faintest outline reveals Satekariwate’s presence. He melts into the dim edge of the lamplight.",
                    backgroundKey = "Officer’s Room — Corner Shadows",
                    autoLine = "Even FitzGibbon glances that way — he senses someone is watching.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = false,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:05–10:12 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "32E_SCOUT_01",
                            label = "Silent Scout",
                            actionType = "Look",
                            responseText = "Even FitzGibbon glances that way — he senses someone is watching."
                        },
                        new HotspotData
                        {
                            id = "32E_CORNER_01",
                            label = "Dim Corner",
                            actionType = "Look",
                            responseText = "The corner is not empty. It is occupied by patience."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "32N",
                        right = "32S",
                        back = "32W",
                        forward = string.Empty
                    }
                },

                ["32S"] = new NodeViewData
                {
                    viewId = "32S",
                    title = "Officer’s Room — Scouts Positioned",
                    description = "Wahsenniyo stands respectfully centered behind Laura. Taren braces subtly at the doorframe, arms folded, watching the hall.",
                    backgroundKey = "Officer’s Room — Scouts Positioned",
                    autoLine = "They stand with me… and because of them, I stand steady.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = false,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:05–10:12 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "32S_ROLES_01",
                            label = "Scout Roles",
                            actionType = "Look",
                            responseText = "They stand with me — Wahsenniyo steady behind me, Taren guarding the door, Satekariwate hidden in shadow."
                        },
                        new HotspotData
                        {
                            id = "32S_TAREN_01",
                            label = "Taren at Door",
                            actionType = "Look",
                            responseText = "Taren does not soften at the threshold of British command. He remains watchful."
                        },
                        new HotspotData
                        {
                            id = "32S_WAHSENNIYO_01",
                            label = "Wahsenniyo’s Stillness",
                            actionType = "Look",
                            responseText = "Wahsenniyo’s stillness gives me strength. My words will not stand alone."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "32E",
                        right = "32W",
                        back = "32N",
                        forward = string.Empty
                    }
                },

                ["33-WARN"] = new NodeViewData
                {
                    viewId = "33-WARN",
                    title = "Warning Delivered — Laura Before FitzGibbon",
                    description = string.Empty,
                    backgroundKey = "Warning Delivered — Laura Before FitzGibbon",
                    autoLine = string.Empty,
                    hotspots = new List<HotspotData>(),
                    navigation = new NavigationTargets
                    {
                        left = string.Empty,
                        right = string.Empty,
                        back = string.Empty,
                        forward = string.Empty
                    },
                    isCutscene = true,
                    dialogueLines = new List<DialogueLine>
                    {
                        new DialogueLine
                        {
                            id = "33W_D01_LAURA",
                            speaker = "Laura",
                            text = "Sir… the Americans intend to march at dawn. A large force. They spoke of coming by the ridge, with scouts in advance. I heard them myself."
                        },
                        new DialogueLine
                        {
                            id = "33W_D02_FITZGIBBON",
                            speaker = "FitzGibbon",
                            text = "How many? Speak plainly."
                        },
                        new DialogueLine
                        {
                            id = "33W_D03_LAURA",
                            speaker = "Laura",
                            text = "Dozens at least in the patrols near our home… and many more behind them. They were preparing supplies. Moving quietly. They mean to strike soon."
                        },
                        new DialogueLine
                        {
                            id = "33W_D04_FITZGIBBON",
                            speaker = "FitzGibbon",
                            text = "And you confirm this?"
                        },
                        new DialogueLine
                        {
                            id = "33W_D05_WAHSENNIYO",
                            speaker = "Wahsenniyo",
                            text = "We tracked their sign days before she came. Her words match what the land already told us."
                        },
                        new DialogueLine
                        {
                            id = "33W_D06_FITZGIBBON",
                            speaker = "FitzGibbon",
                            text = "Then the matter is settled. We act at once. Clerk — bring pen. Orders must be sent."
                        },
                        new DialogueLine
                        {
                            id = "33W_D07_LAURA",
                            speaker = "Laura",
                            text = "I only wish to keep my family safe… and our home."
                        },
                        new DialogueLine
                        {
                            id = "33W_D08_FITZGIBBON",
                            speaker = "FitzGibbon",
                            text = "You have done more than that, Mrs. Secord. You may have saved the whole frontier."
                        }
                    },
                    cutsceneReturnViewId = Node33EntryViewId,
                    cutsceneCompleteFlagName = Act3Scene2WarningDeliveredFlag,
                    cutsceneCompleteMessage = "The weight lifts… not fully, but enough. They believe me. They will act.",
                    cutsceneCompleteButtonLabel = "Continue"
                },

                ["33W"] = new NodeViewData
                {
                    viewId = "33W",
                    title = "The Warning Delivered — Post-Report Room",
                    description = "Laura stands before FitzGibbon, lantern light catching the exhaustion on her face. The room has changed: silence has become action.",
                    backgroundKey = "The Warning Delivered — Post-Report Room",
                    autoLine = "The weight lifts… not fully, but enough. They believe me. They will act.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = false,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:12–10:20 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "33W_FITZGIBBON_01",
                            label = "FitzGibbon’s Decision",
                            actionType = "Look",
                            responseText = "He does not waste words. The warning has become orders before the ink is even dry."
                        },
                        new HotspotData
                        {
                            id = "33W_LAURA_01",
                            label = "Laura’s Exhaustion",
                            actionType = "Look",
                            responseText = "Every mile seems to settle into my bones now that I am believed."
                        },
                        new HotspotData
                        {
                            id = "33W_MAP_01",
                            label = "Map Table",
                            actionType = "Look",
                            responseText = "The map table no longer feels like paper and ink. It feels like motion about to begin."
                        },
                        new HotspotData
                        {
                            id = "33W_WAHSENNIYO_01",
                            label = "Wahsenniyo at Her Shoulder",
                            actionType = "Look",
                            responseText = "He stands with the quiet dignity of one who knew the truth before it reached this room."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "33S",
                        right = "33N",
                        back = "33E",
                        forward = Node34EntryViewId
                    }
                },

                ["33N"] = new NodeViewData
                {
                    viewId = "33N",
                    title = "The Warning Delivered — Clerk and Orders",
                    description = "The clerk writes rapidly, ink flashing under lamplight. FitzGibbon’s orders are already taking form.",
                    backgroundKey = "The Warning Delivered — Clerk and Orders",
                    autoLine = "The clerk writes without pause — action will begin immediately.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = false,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:12–10:20 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "33N_INK_01",
                            label = "Ink Pot",
                            actionType = "Look",
                            responseText = "The ink pot trembles with every quick stroke. A warning becomes command through pen and paper."
                        },
                        new HotspotData
                        {
                            id = "33N_DISPATCH_01",
                            label = "Dispatch Notes",
                            actionType = "Look",
                            responseText = "Dispatch notes are prepared for militia positions and scouting parties."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "33W",
                        right = "33E",
                        back = "33S",
                        forward = string.Empty
                    }
                },

                ["33E"] = new NodeViewData
                {
                    viewId = "33E",
                    title = "The Warning Delivered — Silent Flank",
                    description = "Satekariwate shifts into a new stance, ready to vanish into the night the moment orders are given.",
                    backgroundKey = "The Warning Delivered — Silent Flank",
                    autoLine = "He is ready to vanish into the night the moment orders are given.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = false,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:12–10:20 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "33E_READY_01",
                            label = "Scout Readiness",
                            actionType = "Look",
                            responseText = "He is ready to vanish into the night the moment orders are given."
                        },
                        new HotspotData
                        {
                            id = "33E_SHADOW_01",
                            label = "Shadowed Corner",
                            actionType = "Look",
                            responseText = "The corner seems empty until he chooses to move."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "33N",
                        right = "33S",
                        back = "33W",
                        forward = string.Empty
                    }
                },

                ["33S"] = new NodeViewData
                {
                    viewId = "33S",
                    title = "The Warning Delivered — Wahsenniyo and Taren",
                    description = "Wahsenniyo stands with calm resolve. Taren looks toward the door, ready to move.",
                    backgroundKey = "The Warning Delivered — Wahsenniyo and Taren",
                    autoLine = "They remain steady — the kind of steady one leans on after a day like mine.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = false,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:12–10:20 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "33S_SOLID_01",
                            label = "Scout Solidarity",
                            actionType = "Look",
                            responseText = "They remain steady — the kind of steady one leans on after a day like mine."
                        },
                        new HotspotData
                        {
                            id = "33S_TAREN_01",
                            label = "Taren Ready",
                            actionType = "Look",
                            responseText = "Taren is already thinking of the next movement, the next route, the next danger."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "33E",
                        right = "33W",
                        back = "33N",
                        forward = string.Empty
                    }
                },

                ["34W"] = new NodeViewData
                {
                    viewId = "34W",
                    title = "Orders in Motion — FitzGibbon Issues Orders",
                    description = "FitzGibbon stands at the map table, issuing rapid instructions. A clerk writes furiously while militia men pass through carrying muskets, satchels, and powder horns.",
                    backgroundKey = "Orders in Motion — FitzGibbon Issues Orders",
                    autoLine = "The house erupts into motion — every man called, every scout positioned.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = false,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:20–10:28 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "34W_TABLE_01",
                            label = "Order Table",
                            actionType = "Look",
                            responseText = "British and militia officers coordinated rapid-response patrols based on frontier intelligence."
                        },
                        new HotspotData
                        {
                            id = "34W_MILITIA_01",
                            label = "Militia Movement",
                            actionType = "Look",
                            responseText = "Supplies, arms, and notes move quickly. No wasted motion."
                        },
                        new HotspotData
                        {
                            id = "34W_FITZGIBBON_01",
                            label = "FitzGibbon’s Command",
                            actionType = "Look",
                            responseText = "He does not dramatize the warning. He converts it into orders."
                        },
                        new HotspotData
                        {
                            id = "34W_POWDER_01",
                            label = "Powder Horns",
                            actionType = "Look",
                            responseText = "Powder horns and cartridge boxes are checked at once. The house is becoming a command post in motion."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "34S",
                        right = "34N",
                        back = "34E",
                        forward = Node35EntryViewId
                    }
                },

                ["34N"] = new NodeViewData
                {
                    viewId = "34N",
                    title = "Orders in Motion — Clerk’s Station",
                    description = "A clerk prepares dispatch orders under strong lamplight: one for nearby militia positions, one for scouting parties.",
                    backgroundKey = "Orders in Motion — Clerk’s Station",
                    autoLine = "Ink splashes as orders are written — they must leave within minutes.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = false,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:20–10:28 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "34N_DISPATCH_01",
                            label = "Dispatch Notes",
                            actionType = "Look",
                            responseText = "Orders are written quickly because every minute may change the field."
                        },
                        new HotspotData
                        {
                            id = "34N_INK_01",
                            label = "Ink Splatter",
                            actionType = "Look",
                            responseText = "The ink splashes with the speed of the clerk’s hand. The warning is already moving beyond this room."
                        },
                        new HotspotData
                        {
                            id = "34N_WAX_01",
                            label = "Sealing Wax",
                            actionType = "Look",
                            responseText = "Sealed notes could be carried by runner or rider, depending on urgency and terrain."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "34W",
                        right = "34E",
                        back = "34S",
                        forward = string.Empty
                    }
                },

                ["34E"] = new NodeViewData
                {
                    viewId = "34E",
                    title = "Orders in Motion — Satekariwate at the Shutter",
                    description = "Satekariwate listens through a narrow shutter gap toward the woods. He is still as shadow, but his attention is absolute.",
                    backgroundKey = "Orders in Motion — Satekariwate at the Shutter",
                    autoLine = "He listens for threats — even now, he is the night’s early warning.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = false,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:20–10:28 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "34E_VIGIL_01",
                            label = "Flank Vigilance",
                            actionType = "Look",
                            responseText = "He listens for threats even now. His silence is part of the defense."
                        },
                        new HotspotData
                        {
                            id = "34E_SHUTTER_01",
                            label = "Shutter Gap",
                            actionType = "Look",
                            responseText = "The shutter is opened only a crack. Enough to hear the night, not enough to expose the room."
                        },
                        new HotspotData
                        {
                            id = "34E_WIND_01",
                            label = "Night Wind",
                            actionType = "Listen",
                            responseText = "The faint night wind carries insects, distant dogs, and the possibility of movement."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "34N",
                        right = "34S",
                        back = "34W",
                        forward = string.Empty
                    }
                },

                ["34S"] = new NodeViewData
                {
                    viewId = "34S",
                    title = "Orders in Motion — Wahsenniyo and Taren Prepare",
                    description = "Wahsenniyo confers quietly with Taren near the edge of the map light. Taren adjusts his gear, already thinking of movement.",
                    backgroundKey = "Orders in Motion — Wahsenniyo and Taren Prepare",
                    autoLine = "Their calm is a force of its own — a practiced readiness I envy.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = false,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:20–10:28 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "34S_COORD_01",
                            label = "Scout Coordination",
                            actionType = "Look",
                            responseText = "Their calm is a force of its own — practiced readiness under pressure."
                        },
                        new HotspotData
                        {
                            id = "34S_TAREN_01",
                            label = "Taren’s Gear",
                            actionType = "Look",
                            responseText = "Taren checks his weapon and pack without unnecessary motion."
                        },
                        new HotspotData
                        {
                            id = "34S_ROUTE_01",
                            label = "Wahsenniyo’s Route",
                            actionType = "Look",
                            responseText = "Wahsenniyo speaks little, but every word seems to place someone on the land."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "34E",
                        right = "34W",
                        back = "34N",
                        forward = string.Empty
                    }
                },

                ["35W"] = new NodeViewData
                {
                    viewId = "35W",
                    title = "The Grounds Mobilize — Main Grounds",
                    description = "Outside DeCew House, controlled lantern light catches militia movement, dispatch preparation, and scouts taking position along the yard edge.",
                    backgroundKey = "The Grounds Mobilize — Main Grounds",
                    autoLine = "Everything moves at once — orders, horses, men, scouts. The warning has set the whole house in motion.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:28–10:40 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "35W_LANTERN_01",
                            label = "Controlled Lantern Light",
                            actionType = "Look",
                            responseText = "Lanterns would likely have been kept low and controlled near an active outpost — enough light for preparation, not enough to advertise movement outside."
                        },
                        new HotspotData
                        {
                            id = "35W_FORMUP_01",
                            label = "Militia Form-Up",
                            actionType = "Look",
                            responseText = "Small detachments and scouts could move more quickly than large formations, especially through wooded Niagara terrain."
                        },
                        new HotspotData
                        {
                            id = "35W_FITZGIBBON_01",
                            label = "FitzGibbon Acting",
                            actionType = "Look",
                            responseText = "FitzGibbon shifts from receiving the warning to issuing immediate direction for a rapid response."
                        },
                        new HotspotData
                        {
                            id = "35W_RECONSTRUCTION_01",
                            label = "Historical Reconstruction",
                            actionType = "Look",
                            responseText = "Laura Secord’s warning to FitzGibbon is historically central to the events leading to Beaver Dams. The exact minute-by-minute activity at DeCew House is reconstructed here from plausible outpost behavior, allied scouting needs, and rapid military response."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "35S",
                        right = "35N",
                        back = "35E",
                        forward = Node36EntryViewId
                    }
                },

                ["35N"] = new NodeViewData
                {
                    viewId = "35N",
                    title = "The Grounds Mobilize — Horse Line and Runners",
                    description = "Runners check dispatch notes while horses are steadied nearby for movement where terrain permits.",
                    backgroundKey = "The Grounds Mobilize — Horse Line and Runners",
                    autoLine = "Runners and horses prepare in parallel — orders must travel quickly into the night.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:28–10:40 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "35N_RUNNER_01",
                            label = "Runners Preparing",
                            actionType = "Look",
                            responseText = "At an active outpost, messengers could be readied quickly to carry written or spoken orders between positions."
                        },
                        new HotspotData
                        {
                            id = "35N_HORSE_01",
                            label = "Horse Line",
                            actionType = "Look",
                            responseText = "Horses may have been prepared for faster dispatch where routes allowed, while other messages would likely go on foot."
                        },
                        new HotspotData
                        {
                            id = "35N_WAX_01",
                            label = "Sealed Dispatch",
                            actionType = "Look",
                            responseText = "In frontier conditions, notes could be sealed and handed off quickly for a rapid response across scattered positions."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "35W",
                        right = "35E",
                        back = "35S",
                        forward = string.Empty
                    }
                },

                ["35E"] = new NodeViewData
                {
                    viewId = "35E",
                    title = "The Grounds Mobilize — Scout Assembly",
                    description = "Allied scouts gather in low light near the yard edge, speaking briefly and preparing to move by quieter routes.",
                    backgroundKey = "The Grounds Mobilize — Scout Assembly",
                    autoLine = "Scouts assemble in near silence, preparing to move before larger bodies can follow.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:28–10:40 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "35E_SCOUT_01",
                            label = "Scout Assembly",
                            actionType = "Look",
                            responseText = "Indigenous scouts could gather quietly at the edge of light, ready to move ahead of larger detachments."
                        },
                        new HotspotData
                        {
                            id = "35E_SIGNAL_01",
                            label = "Quiet Signals",
                            actionType = "Look",
                            responseText = "Near an active outpost, silent signals would likely have been preferred over raised voices once movement began."
                        },
                        new HotspotData
                        {
                            id = "35E_TREE_01",
                            label = "Tree Line",
                            actionType = "Look",
                            responseText = "The edge of the woods offers cover and listening ground for scouts preparing routes in the dark."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "35N",
                        right = "35S",
                        back = "35W",
                        forward = string.Empty
                    }
                },

                ["35S"] = new NodeViewData
                {
                    viewId = "35S",
                    title = "The Grounds Mobilize — Wahsenniyo and FitzGibbon Coordination",
                    description = "Wahsenniyo and FitzGibbon confer at the edge of lantern light, matching land knowledge to immediate command decisions.",
                    backgroundKey = "The Grounds Mobilize — Wahsenniyo and FitzGibbon Coordination",
                    autoLine = "Command and land knowledge align here — urgency without confusion.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:28–10:40 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "35S_COORD_01",
                            label = "Shared Planning",
                            actionType = "Look",
                            responseText = "Wahsenniyo and FitzGibbon coordinate quickly — command intent and land knowledge working together for a rapid response."
                        },
                        new HotspotData
                        {
                            id = "35S_TAREN_01",
                            label = "Taren Preparing",
                            actionType = "Look",
                            responseText = "Taren checks his gear with practiced economy, ready for movement once direction is given."
                        },
                        new HotspotData
                        {
                            id = "35S_ROUTE_01",
                            label = "Route Talk",
                            actionType = "Look",
                            responseText = "Likely routes are weighed for cover, speed, and how quickly scouts can relay what they find."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "35E",
                        right = "35W",
                        back = "35N",
                        forward = string.Empty
                    }
                },

                ["36W"] = new NodeViewData
                {
                    viewId = "36W",
                    title = "Deployment — Forming the Night Column",
                    description = "Militia men form into a loose night column at the edge of the field. FitzGibbon stands near the front with his lantern shielded, checking final positions. Wahsenniyo and the allied scouts gather just off the flank.",
                    backgroundKey = "Deployment — Forming the Night Column",
                    autoLine = "This is the moment… when everything learned tonight becomes action.",
                    facingDirection = "W",
                    cameraBearing = 270,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:40–10:55 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "36W_PATH_01",
                            label = "Path Into Darkness",
                            actionType = "Look",
                            responseText = "Allied troops moved without torches when secrecy mattered — trusting scouts, moonlight, and familiarity with the land rather than giving away position."
                        },
                        new HotspotData
                        {
                            id = "36W_SCOUTS_01",
                            label = "Scout Line",
                            actionType = "Look",
                            responseText = "The scouts lead the way — silent, certain, and ahead of every footfall."
                        },
                        new HotspotData
                        {
                            id = "36W_FITZGIBBON_01",
                            label = "FitzGibbon’s Final Check",
                            actionType = "Look",
                            responseText = "FitzGibbon checks positions quickly. The warning is no longer being discussed — it is being acted upon."
                        },
                        new HotspotData
                        {
                            id = "36W_COLUMN_01",
                            label = "Night Column",
                            actionType = "Look",
                            responseText = "A loose night column can move more quietly than a crowded formation, especially near woods and uneven ground."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "36S",
                        right = "36N",
                        back = "36E",
                        forward = Node37PlaceholderTarget
                    }
                },

                ["36N"] = new NodeViewData
                {
                    viewId = "36N",
                    title = "Deployment — Ridge-Facing Trees",
                    description = "Tree silhouettes rise toward the northern ridge. The scouts study the slope without speaking.",
                    backgroundKey = "Deployment — Ridge-Facing Trees",
                    autoLine = "Those trees hide routes only the scouts truly know.",
                    facingDirection = "N",
                    cameraBearing = 0,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:40–10:55 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "36N_RIDGE_01",
                            label = "Ridge Path Hint",
                            actionType = "Look",
                            responseText = "Those trees hide routes only the scouts truly know."
                        },
                        new HotspotData
                        {
                            id = "36N_CANOPY_01",
                            label = "Dark Canopy",
                            actionType = "Look",
                            responseText = "The canopy swallows light quickly. Anyone moving there without knowledge would lose direction."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "36W",
                        right = "36E",
                        back = "36S",
                        forward = string.Empty
                    }
                },

                ["36E"] = new NodeViewData
                {
                    viewId = "36E",
                    title = "Deployment — Final Look at DeCew House",
                    description = "DeCew House glows dimly behind the assembling column. Movement continues inside, steady and purposeful.",
                    backgroundKey = "Deployment — Final Look at DeCew House",
                    autoLine = "The house that held my warning… now prepares its defenders.",
                    facingDirection = "E",
                    cameraBearing = 90,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:40–10:55 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "36E_LANTERN_01",
                            label = "Shaded Lanterns",
                            actionType = "Look",
                            responseText = "Lanterns would likely be shaded or controlled near the outpost, preserving enough light for work without exposing the house more than necessary."
                        },
                        new HotspotData
                        {
                            id = "36E_HOUSE_01",
                            label = "House in Motion",
                            actionType = "Look",
                            responseText = "The house that held my warning now prepares its defenders."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "36N",
                        right = "36S",
                        back = "36W",
                        forward = string.Empty
                    }
                },

                ["36S"] = new NodeViewData
                {
                    viewId = "36S",
                    title = "Deployment — Gear and Provisions Check",
                    description = "A small cluster of militia men check belts, bayonets, powder bags, and straps. Every movement is quiet and practiced.",
                    backgroundKey = "Deployment — Gear and Provisions Check",
                    autoLine = "Every strap and pouch must be perfect — darkness punishes mistakes.",
                    facingDirection = "S",
                    cameraBearing = 180,
                    showCompass = true,
                    historicalDate = "June 22, 1813",
                    localTimeWindow = "10:40–10:55 p.m.",
                    showHistoricalTime = true,
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "36S_GEAR_01",
                            label = "Gear Check",
                            actionType = "Look",
                            responseText = "Every strap and pouch must be checked before moving in darkness. Small mistakes become dangerous at night."
                        },
                        new HotspotData
                        {
                            id = "36S_POWDER_01",
                            label = "Powder Bags",
                            actionType = "Look",
                            responseText = "Powder had to stay dry and accessible. Dampness, darkness, and haste were a bad combination."
                        },
                        new HotspotData
                        {
                            id = "36S_QUIET_01",
                            label = "Quiet Preparation",
                            actionType = "Listen",
                            responseText = "The preparation is quiet by necessity. Loud readiness would defeat itself."
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "36E",
                        right = "36W",
                        back = "36N",
                        forward = string.Empty
                    }
                },

                ["3W"] = new NodeViewData
                {
                    viewId = "3W",
                    title = "Front Hall — Toward Kitchen",
                    description = "The hallway angles toward the kitchen side, where dim light and occupied silence mingle.",
                    backgroundKey = "S01_N03_3W",
                    autoLine = "The kitchen side of the hall offers movement, but every board could betray me.",
                    hotspots = new List<HotspotData>
                    {
                        new HotspotData
                        {
                            id = "3W_KITCHEN_01",
                            label = "Kitchen Passage",
                            actionType = "Look",
                            responseText = "The passage toward the kitchen is narrow and exposed, but it remains passable."
                        },
                        new HotspotData
                        {
                            id = "3W_FLOOR_01",
                            label = "Floorboards",
                            actionType = "Look",
                            responseText = "The floorboards are worn smooth by years of traffic and tonight they answer every step."
                        },
                        new HotspotData
                        {
                            id = "3W_EXIT_01",
                            label = "Kitchen Exit",
                            actionType = "Exit",
                            responseText = "The kitchen side offers a brief opening to slip through.",
                            targetViewId = Node2KitchenEntryViewId
                        }
                    },
                    navigation = new NavigationTargets
                    {
                        left = "3S",
                        right = "3N",
                        back = "3E",
                        forward = Node1ATopOfStairsViewId
                    }
                }
            };
        }
    }
}
