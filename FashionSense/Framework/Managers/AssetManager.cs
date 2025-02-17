﻿using FashionSense.Framework.Models.Appearances.Body;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using System.Collections.Generic;
using System.IO;

namespace FashionSense.Framework.Managers
{
    internal class AssetManager
    {
        internal string assetFolderPath;
        internal Dictionary<string, Texture2D> toolNames = new Dictionary<string, Texture2D>();

        // Tool textures
        private Texture2D _handMirrorTexture;

        // UI textures
        internal readonly Texture2D scissorsButtonTexture;
        internal readonly Texture2D accessoryButtonTexture;
        internal readonly Texture2D hatButtonTexture;
        internal readonly Texture2D shirtButtonTexture;
        internal readonly Texture2D pantsButtonTexture;
        internal readonly Texture2D sleevesAndShoesButtonTexture;
        internal readonly Texture2D sleevesButtonTexture;
        internal readonly Texture2D shoesButtonTexture;
        internal readonly Texture2D bodyButtonTexture;
        internal readonly Texture2D exportButton;

        // Appearances
        internal IContentPack localPack;

        public AssetManager(IModHelper helper)
        {
            // Get the asset folder path
            assetFolderPath = helper.ModContent.GetInternalAssetName(Path.Combine("Framework", "Assets")).Name;

            // Load in the UI assets
            _handMirrorTexture = helper.ModContent.Load<Texture2D>(Path.Combine(assetFolderPath, "HandMirror.png"));
            scissorsButtonTexture = helper.ModContent.Load<Texture2D>(Path.Combine(assetFolderPath, "UI", "HairButton.png"));
            accessoryButtonTexture = helper.ModContent.Load<Texture2D>(Path.Combine(assetFolderPath, "UI", "AccessoryButton.png"));
            hatButtonTexture = helper.ModContent.Load<Texture2D>(Path.Combine(assetFolderPath, "UI", "HatButton.png"));
            shirtButtonTexture = helper.ModContent.Load<Texture2D>(Path.Combine(assetFolderPath, "UI", "ShirtButton.png"));
            pantsButtonTexture = helper.ModContent.Load<Texture2D>(Path.Combine(assetFolderPath, "UI", "PantsButton.png"));
            sleevesButtonTexture = helper.ModContent.Load<Texture2D>(Path.Combine(assetFolderPath, "UI", "SleevesButton.png"));
            sleevesAndShoesButtonTexture = helper.ModContent.Load<Texture2D>(Path.Combine(assetFolderPath, "UI", "SleevesShoesButton.png"));
            shoesButtonTexture = helper.ModContent.Load<Texture2D>(Path.Combine(assetFolderPath, "UI", "ShoesButton.png"));
            bodyButtonTexture = helper.ModContent.Load<Texture2D>(Path.Combine(assetFolderPath, "UI", "BodyButton.png"));
            exportButton = helper.ModContent.Load<Texture2D>(Path.Combine(assetFolderPath, "UI", "ExportButton.png"));

            // Setup toolNames
            toolNames.Add("HandMirror", _handMirrorTexture);
        }

        internal IContentPack GetLocalPack(bool update = false)
        {
            if (localPack is null || update is true)
            {
                localPack = FashionSense.modHelper.ContentPacks.CreateTemporary(Path.Combine(FashionSense.modHelper.DirectoryPath, "Framework", "Assets", "Local Pack"), "PeacefulEnd.FashionSense.LocalPack", "FS - Local Pack", "The local appearance pack for the Fashion Sense framework.", FashionSense.modManifest.Author, FashionSense.modManifest.Version);
            }
            return localPack;
        }

        internal Texture2D GetHandMirrorTexture()
        {
            return _handMirrorTexture;
        }
    }
}
