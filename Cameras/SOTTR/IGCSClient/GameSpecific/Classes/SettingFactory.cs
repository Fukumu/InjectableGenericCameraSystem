﻿////////////////////////////////////////////////////////////////////////////////////////////////////////
// Part of Injectable Generic Camera System
// Copyright(c) 2019, Frans Bouma
// All rights reserved.
// https://github.com/FransBouma/InjectableGenericCameraSystem
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met :
//
//  * Redistributions of source code must retain the above copyright notice, this
//	  list of conditions and the following disclaimer.
//
//  * Redistributions in binary form must reproduce the above copyright notice,
//    this list of conditions and the following disclaimer in the documentation
//    and / or other materials provided with the distribution.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED.IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IGCSClient.Classes;

namespace IGCSClient.GameSpecific.Classes
{
	/// <summary>
	/// Creates setting instances for the setting editor. It defines the setting defaults/min/max values for the various settings based
	/// on the game it will be used with.
	/// </summary>
	public static class SettingFactory
	{
		public static void InitializeSettings()
		{
			var appState = AppStateSingleton.Instance();
			appState.AddSetting(new FloatSetting(SettingType.FastMovementMultiplier, nameof(SettingType.FastMovementMultiplier), 0.1M, 100.0M, 2, 0.01M, GameSpecificSettingDefaults.FastMovementMultiplier));
			appState.AddSetting(new FloatSetting(SettingType.SlowMovementMultiplier, nameof(SettingType.SlowMovementMultiplier), 0.001M, 1.0M, 3, 0.001M, GameSpecificSettingDefaults.SlowMovementMultiplier));
			appState.AddSetting(new FloatSetting(SettingType.UpMovementMultiplier, nameof(SettingType.UpMovementMultiplier), 0.1M, 10.0M, 2, 0.01M, GameSpecificSettingDefaults.UpMovementMultiplier));
			appState.AddSetting(new FloatSetting(SettingType.MovementSpeed, nameof(SettingType.MovementSpeed), 0.1M, 3.0M, 2, 0.01M, GameSpecificSettingDefaults.MovementSpeed));
			appState.AddSetting(new DropDownSetting(SettingType.CameraControlDevice, nameof(SettingType.CameraControlDevice),
													new List<string>()
													{
														nameof(CameraDeviceType.KeyboardMouse), nameof(CameraDeviceType.Gamepad), nameof(CameraDeviceType.Both)
													}, GameSpecificSettingDefaults.CameraControlDevice));
			appState.AddSetting(new FloatSetting(SettingType.RotationSpeed, nameof(SettingType.RotationSpeed), 0.001M, 0.5M, 3, 0.001M, GameSpecificSettingDefaults.RotationSpeed));
			appState.AddSetting(new BoolSetting(SettingType.InvertYLookDirection, nameof(SettingType.InvertYLookDirection), GameSpecificSettingDefaults.InvertYLookDirection));
			appState.AddSetting(new FloatSetting(SettingType.FoVZoomSpeed, nameof(SettingType.FoVZoomSpeed), 0.0001M, 0.01M, 4, 0.0001M, GameSpecificSettingDefaults.FoVZoomSpeed));
			appState.AddSetting(new FolderSetting(SettingType.ShotOutputFolder, nameof(SettingType.ShotOutputFolder), 
												  Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Please select the screenshot output directory"));
			appState.AddSetting(new IntSetting(SettingType.ShotFramesToWait, nameof(SettingType.ShotFramesToWait), 1, 100, 1, GameSpecificSettingDefaults.ShotFramesToWait));
			appState.AddSetting(new DropDownSetting(SettingType.ShotType, nameof(SettingType.ShotType), new List<string>()
																										{
																											nameof(ScreenshotType.HorizontalPanorama), 
																											nameof(ScreenshotType.Lightfield)
																										}, GameSpecificSettingDefaults.ShotType));
			appState.AddSetting(new FloatSetting(SettingType.PanoTotalFoV, nameof(SettingType.PanoTotalFoV), 30.0M, 359.0M, 1, 0.1M, GameSpecificSettingDefaults.PanoTotalFoV));
			appState.AddSetting(new FloatSetting(SettingType.PanoOverlapPercentage, nameof(SettingType.PanoOverlapPercentage), 0.1M, 99.9M, 1, 0.1M, GameSpecificSettingDefaults.PanoOverlapPercentage));
			appState.AddSetting(new FloatSetting(SettingType.LightfieldDistance, nameof(SettingType.LightfieldDistance), 0.001M, 5.0M, 3, 0.001M, GameSpecificSettingDefaults.LightfieldDistance));
			appState.AddSetting(new IntSetting(SettingType.LightfieldShotCount, nameof(SettingType.LightfieldShotCount), 0, 60, 1, GameSpecificSettingDefaults.LightfieldShotCount));
			appState.AddSetting(new DropDownSetting(SettingType.ShotFileType, nameof(SettingType.ShotFileType), new List<string>()
																												{
																													nameof(ScreenshotFileType.Bmp), nameof(ScreenshotFileType.Jpeg), 
																													nameof(ScreenshotFileType.Png)
																												}, GameSpecificSettingDefaults.ShotFileType));
		}


		public static void InitializeKeyBindings()
		{
			var appState = AppStateSingleton.Instance();
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.BlockInputToGame, nameof(KeyBindingType.BlockInputToGame), new KeyCombination(GameSpecificKeyBindingDefaults.BlockInputToGameDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.EnableDisableCamera, nameof(KeyBindingType.EnableDisableCamera), new KeyCombination(GameSpecificKeyBindingDefaults.EnableDisableCameraDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.DecreaseFoV, nameof(KeyBindingType.DecreaseFoV), new KeyCombination(GameSpecificKeyBindingDefaults.DecreaseFoVDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.IncreaseFoV, nameof(KeyBindingType.IncreaseFoV), new KeyCombination(GameSpecificKeyBindingDefaults.IncreaseFoVDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.ResetFoV, nameof(KeyBindingType.ResetFoV), new KeyCombination(GameSpecificKeyBindingDefaults.ResetFoVDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.LockUnlockCameraMovement, nameof(KeyBindingType.LockUnlockCameraMovement), new KeyCombination(GameSpecificKeyBindingDefaults.LockUnlockCameraMovementDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.MoveCameraLeft, nameof(KeyBindingType.MoveCameraLeft), new KeyCombination(GameSpecificKeyBindingDefaults.MoveCameraLeftDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.MoveCameraRight, nameof(KeyBindingType.MoveCameraRight), new KeyCombination(GameSpecificKeyBindingDefaults.MoveCameraRightDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.MoveCameraForward, nameof(KeyBindingType.MoveCameraForward), new KeyCombination(GameSpecificKeyBindingDefaults.MoveCameraForwardDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.MoveCameraBackward, nameof(KeyBindingType.MoveCameraBackward), new KeyCombination(GameSpecificKeyBindingDefaults.MoveCameraBackwardDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.MoveCameraUp, nameof(KeyBindingType.MoveCameraUp), new KeyCombination(GameSpecificKeyBindingDefaults.MoveCameraUpDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.MoveCameraDown, nameof(KeyBindingType.MoveCameraDown), new KeyCombination(GameSpecificKeyBindingDefaults.MoveCameraDownDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.RotateCameraUp, nameof(KeyBindingType.RotateCameraUp), new KeyCombination(GameSpecificKeyBindingDefaults.RotateCameraUpDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.RotateCameraDown, nameof(KeyBindingType.RotateCameraDown), new KeyCombination(GameSpecificKeyBindingDefaults.RotateCameraDownDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.RotateCameraLeft, nameof(KeyBindingType.RotateCameraLeft), new KeyCombination(GameSpecificKeyBindingDefaults.RotateCameraLeftDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.RotateCameraRight, nameof(KeyBindingType.RotateCameraRight), new KeyCombination(GameSpecificKeyBindingDefaults.RotateCameraRightDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.TiltCameraLeft, nameof(KeyBindingType.TiltCameraLeft), new KeyCombination(GameSpecificKeyBindingDefaults.TiltCameraLeftDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.TiltCameraRight, nameof(KeyBindingType.TiltCameraRight), new KeyCombination(GameSpecificKeyBindingDefaults.TiltCameraRightDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.TestMultiShotSetup, nameof(KeyBindingType.TestMultiShotSetup), new KeyCombination(GameSpecificKeyBindingDefaults.TestMultiShotSetupDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.TakeShot, nameof(KeyBindingType.TakeShot), new KeyCombination(GameSpecificKeyBindingDefaults.TakeShotDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.TakeMultiShot, nameof(KeyBindingType.TakeMultiShot), new KeyCombination(false, true, false, GameSpecificKeyBindingDefaults.TakeMultiShotDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.ToggleHUD, nameof(KeyBindingType.ToggleHUD), new KeyCombination(GameSpecificKeyBindingDefaults.ToggleHUDDefault)));
			appState.AddKeyBinding(new KeyBindingSetting(KeyBindingType.PauseUnpauseGame, nameof(KeyBindingType.PauseUnpauseGame), new KeyCombination(GameSpecificKeyBindingDefaults.PauseUnpauseGameDefault)));
		}
	}
}
