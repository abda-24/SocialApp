namespace ServiceAbstraction
{
    public interface IServiceManger
    {
        public IPostService PostService { get; }
        public ICommentService CommentService { get; }
        public ILikeService LikeService { get; }
        public IFriendshipService FriendshipService { get; }
        public IMessageService MessageService { get; }
        public IConversations conversationService {  get; }
        public INotificationService notificationService { get; }
        public ISearchService searchService { get; }
        public IFeedService feedService { get; }
        public IAIRecommendationService aIRecommendationService { get; }
        public IUserProfileService userProfileService { get; }
        public IExploreService exploreService { get; }
        public IFileService fileService { get; }
        public IAuthService authService { get; }



    }
}
