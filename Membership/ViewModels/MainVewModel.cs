using Membership.Data;
using Membership.Model;
using Membership.Views;
using System.Collections.Generic;
using System.Linq;

namespace Membership.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMemberRepository _memberRepository;
        public static int memberId = 0;

        public MainViewModel()
        {
            _memberRepository = new MemberRepository();
            InitData();
        }

        private void InitData()
        {
            _members = new();
            Members = new();
            _selectedMember = new();
            SelectedMember = new();
            Members = _memberRepository.GetAllMembers();
            if(memberId  > 0)
            {
                SelectedActiveMember = Members.FirstOrDefault(c => c.Id == memberId) ?? new();
            }
        }

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

        private Member _selectedActiveMember;
        public Member SelectedActiveMember
        {
            get { return _selectedMember; }
            set { SetProperty(ref _selectedMember, value); }
        }


        private void OpenMemberDetails()
        {
            if (SelectedMember != null && SelectedMember.Id > 0)
            {
                MainViewModel.memberId = SelectedMember.Id;
                MainWindow.appViewModel.ActiveWindow = new MemberDetails();
            }
        }

    }
}
