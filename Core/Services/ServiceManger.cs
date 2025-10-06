using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Presentation.Hubs;
using Services.Auth;
using Services.Comments;
using Services.Conversations;
using Services.Explore;
using Services.Feed;
using Services.File;
using Services.Friends;
using Services.Likes;
using Services.Messagess;
using Services.Notifications;
using Services.PostService;
using Services.Profile;
using Services.Recommendation;
using Services.Search;

namespace ServiceAbstraction
{
    public class ServiceManger(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, IConfiguration configuration, IHubContext<NotificationHub> notificationHub, IWebHostEnvironment env) : IServiceManger
    {
        private readonly Lazy<IPostService> _LazyPostService = new Lazy<IPostService>(() => new PostService(unitOfWork, mapper));
        public IPostService PostService => _LazyPostService.Value;

        private readonly Lazy<ICommentService> _LazyCommentService = new Lazy<ICommentService>(() => new CommentService(unitOfWork, mapper,notificationHub));
        public ICommentService CommentService => _LazyCommentService.Value;

        private readonly Lazy<ILikeService> _LazyLikeService = new Lazy<ILikeService>(() => new LikeService(unitOfWork,mapper,notificationHub));
        public ILikeService LikeService => _LazyLikeService.Value;

        private readonly Lazy<IFriendshipService> _LazyFriendshipService = new Lazy<IFriendshipService>(() => new FriendshipService(unitOfWork, mapper,notificationHub));
        public IFriendshipService FriendshipService => _LazyFriendshipService.Value;

        private readonly Lazy<IMessageService>_LazymessageService =  new Lazy<IMessageService>(()=> new MessageService(unitOfWork,mapper));
        public IMessageService MessageService => _LazymessageService.Value;

        private readonly Lazy<IConversations> _LazyconversationsServic =new Lazy<IConversations>(()=> new ConversationService(unitOfWork,mapper));
        public IConversations conversationService => _LazyconversationsServic.Value;

        private readonly Lazy<INotificationService> _LazyNotificationService = new Lazy<INotificationService>(() => new NotificationService( unitOfWork,mapper));
        public INotificationService notificationService => _LazyNotificationService.Value;

        private readonly Lazy<ISearchService> _LazySearchService = new Lazy<ISearchService>(() => new SearchService(unitOfWork, mapper));
        public ISearchService searchService => _LazySearchService.Value;

        private readonly Lazy<IFeedService> _LazyFeedService = new Lazy<IFeedService>(()=> new FeedService(unitOfWork,mapper));
        public IFeedService feedService => _LazyFeedService.Value;

        private readonly Lazy<IAIRecommendationService> _LazyAIRecommendationService = new Lazy<IAIRecommendationService>(() => new AIRecommendationService(unitOfWork,mapper));
        public IAIRecommendationService aIRecommendationService =>_LazyAIRecommendationService.Value;

        private readonly Lazy<IUserProfileService> _LazyUserProfileService = new Lazy<IUserProfileService>(() => new UserProfileService(unitOfWork, mapper));
        public IUserProfileService userProfileService => _LazyUserProfileService.Value;

        private readonly Lazy<IExploreService> _LazyExploreService = new Lazy<IExploreService>(() => new ExploreService(unitOfWork, mapper));
        public IExploreService exploreService => _LazyExploreService.Value;

        private readonly Lazy<IFileService> _LazyFileService = new Lazy<IFileService>(() => new FileService(unitOfWork, mapper,env));
        public IFileService fileService => _LazyFileService.Value;
        private readonly Lazy<IAuthService> _LazyauthService = new Lazy<IAuthService>(()=> new AuthService(userManager,configuration,mapper));
        public IAuthService authService => throw new NotImplementedException();
    }
}

    