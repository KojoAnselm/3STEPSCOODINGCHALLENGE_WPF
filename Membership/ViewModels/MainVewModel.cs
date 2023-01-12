using Membership.Data;
using Membership.Model;
using Membership.Views;
using Prism.Commands;
using System.Collections.Generic;
using System.Linq;

namespace Membership.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMemberRepository _memberRepository;
        public static int memberId;

        public DelegateCommand _PreviousCommand;
        public DelegateCommand PreviousCommand
        {
            get { return _PreviousCommand; }
            set { SetProperty(ref _PreviousCommand, value); }
        }
        public DelegateCommand NextCommand { get; set;  }
        public DelegateCommand CloseCommand { get; set; }

        public MainViewModel()
        {
            _memberRepository = new MemberRepository();
            InitCommands();
            InitData();
        }

        private void InitCommands()
        {
            PreviousCommand = new DelegateCommand(GetPreviousRecord,CanGotoPrevious);
            NextCommand = new DelegateCommand(GetNextRecord,CanGotoNext);
            CloseCommand = new DelegateCommand(OpenMainWindow);
        }


        #region Command Methods

        private bool CanGotoPrevious()
        {
            var MaxRecId = Members?.OrderBy(c => c.Id)?.LastOrDefault()?.Id;
            var MinRecId = Members?.OrderBy(c => c.Id)?.FirstOrDefault()?.Id;

            if (SelectedActiveMember.Id == MinRecId)
            {
                return false;
            }
            else if (SelectedActiveMember.Id > MinRecId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CanGotoNext()
        {
            var MinRecId = Members?.OrderBy(c => c.Id)?.FirstOrDefault()?.Id;
            var MaxRecId = Members?.OrderBy(c => c.Id)?.LastOrDefault()?.Id;
            if (SelectedActiveMember.Id == MaxRecId)
            {
                return false;
            }
            else if (SelectedActiveMember.Id >= MinRecId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void OpenMainWindow()
        {
            memberId = 0;
            MainWindow.appViewModel.ActiveWindow = new MemberList();
        }

        private  void GetNextRecord()
        {
            if (_selectedActiveMember != null && _selectedActiveMember.Id > 0)
            {
                var results = Members.SkipWhile(x => x.Id != SelectedActiveMember.Id).Skip(1).FirstOrDefault();
                if (results is not null || results?.Id > 0)
                    SelectedActiveMember = results;
                else
                    SelectedActiveMember = Members.First();
            }

            //To enable Previous and Next Button Visibility at each stage
            NavigationButtonEnablingCheck();
        }

        private void NavigationButtonEnablingCheck()
        {
            PreviousCommand = new DelegateCommand(GetPreviousRecord, CanGotoPrevious);
            IsNextEnabled =  CanGotoNext();
        }

        private void GetPreviousRecord()
        {
            if (_selectedActiveMember != null && _selectedActiveMember.Id > 0)
            {
                var results = Members.TakeWhile(x => !x.Equals(SelectedActiveMember)).Last(); ;
                if (results is not null || results?.Id > 0)
                    SelectedActiveMember = results;
                else
                    SelectedActiveMember = Members.Last();

            }
            //To enable Previous and Next Button Visibility at each stage
            NavigationButtonEnablingCheck();
        }

        private void OpenMemberDetails()
        {
            if (SelectedMember != null && SelectedMember.Id > 0)
            {
                MainViewModel.memberId = SelectedMember.Id;
                MainWindow.appViewModel.ActiveWindow = new MemberDetails();
            }
        }

        private void InitData()
        {
            Members = _memberRepository.GetAllMembers();
            if (memberId > 0)
            {
                SelectedActiveMember = Members.FirstOrDefault(c => c.Id == memberId) ?? new();
            }
        }

        #endregion

        #region Properties
        private List<Member> _members;
        public List<Member> Members
        {
            get => _members;
            set => SetProperty(ref _members, value);
        }

        private Member _selectedMember;
        public Member SelectedMember
        {
            get { return _selectedMember; }
            set { SetProperty(ref _selectedMember, value); OpenMemberDetails(); }
        }

        private  Member _selectedActiveMember;
        public Member SelectedActiveMember
        {
            get { return _selectedActiveMember; }
            set { SetProperty(ref _selectedActiveMember, value); }
        }

        private bool _isNextEnabled = true;
        public bool IsNextEnabled
        {
            get { return _isNextEnabled; }
            set { SetProperty(ref _isNextEnabled, value); }
        }

        #endregion


    }
}
