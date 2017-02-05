﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Events;

namespace MasterDetailExample.ViewModels
{
	public class MasterDetailPageViewModel : BaseViewModel
	{
		private IEventAggregator _eventAggregator;

		public MasterDetailPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator):base(navigationService)
		{
			_eventAggregator = eventAggregator;
			Title = "MasterDetailPageView";

			_eventAggregator.GetEvent<DetailPageViewNavigationEvent>().Subscribe(NavigateToDetailPageView);
		}

		public override void OnNavigatedFrom(NavigationParameters parameters)
		{
			base.OnNavigatedFrom(parameters);
		}

		public override void OnNavigatedTo(NavigationParameters parameters)
		{
			base.OnNavigatedTo(parameters);
		}

		private async void NavigateToDetailPageView(DetailPageViewNavigationMessage message)
		{
			var parameter = new NavigationParameters($"id={message.Id}");
			await _navigationService.NavigateAsync("BaseNavigationPageView/DetailPageView", parameter);
		}
	}
}
