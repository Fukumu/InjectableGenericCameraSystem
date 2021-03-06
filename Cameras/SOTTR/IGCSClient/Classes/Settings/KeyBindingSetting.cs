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
using IGCSClient.Controls;
using IGCSClient.Interfaces;

namespace IGCSClient.Classes
{
	public class KeyBindingSetting : Setting<KeyCombination>
	{
		#region Members
		private KeyCombination _initialCombination;
		#endregion

		public KeyBindingSetting(byte id, string name, KeyCombination initialCombination) 
			: base(id, name, SettingKind.KeyBinding)
		{
			_initialCombination = initialCombination;
		}


		public override void Setup(IInputControl<KeyCombination> controlToUse)
		{
			base.Setup(controlToUse);
			KeyCombinationInput controlAsCombinationInput = controlToUse as KeyCombinationInput;
			if(controlAsCombinationInput == null)
			{
				return;
			}
			controlAsCombinationInput.Setup(_initialCombination);
		}


		protected override string GetValueAsString()
		{
			return this.Value.GetValueAsString();
		}


		protected override KeyCombination GetDefaultValue()
		{
			return _initialCombination;
		}


		public override void SendValueAsMessage()
		{
			MessageHandlerSingleton.Instance().SendKeyBindingMessage(this.ID, this.Value.GetValueAsByteArray());
		}
	}
}
