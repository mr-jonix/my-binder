using MyBinder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SearchAgent : MonoBehaviour {

    public static SearchAgent instance = null;
    public CardView cardView;
    public AlbumView albumView;
    public CardFilter filter;
    public List<MTGCard> currentSearchResults;
    public bool isUpdated = false;

    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (isUpdated)
        {
            isUpdated = false;
            PerformSearch();
            albumView.UpdateCardViews(currentSearchResults);
            if (currentSearchResults.Count > 0)
            {
                cardView.SetCardLink(currentSearchResults[0]);
            }
        }
    }

    public void PerformSearch()
    {
        var englishName = new EnglishNameSpecification(filter.name);
        var foreignCardTemplate = new ForeignDataObject() { name = filter.name.ToLower(), language = "Russian" };
        var foreignName = new ForeignNameSpecification(foreignCardTemplate);
        var convertedManaCost = new CMCSpecification(filter.convertedManaCost);
        var isWhite = new IsWhiteSpecification();
        var isBlue = new IsBlueSpecification();
        var isBlack = new IsBlackSpecification();
        var isRed = new IsRedSpecification();
        var isGreen = new IsGreenSpecification();
        var isColorless = new IsColorlessSpecification();
        var isMulticolored = new IsMulticoloredSpecification();
        var isCreature = new IsCreatureSpecification();
        var isArtifact = new IsArtifactSpecification();
        var isLand = new IsLandSpecification();
        var isInstant = new IsInstantSpecification();
        var isSorcery = new IsSorcerySpecification();
        var isEnchantment = new IsEnchantmentSpecification();
        var isPlaneswalker = new IsPlaneswalkerSpecification();
        var isTribal = new IsTribalSpecification();

        var resultingSpecification = englishName.Or(foreignName);
        resultingSpecification = resultingSpecification.And(convertedManaCost);

        switch (filter.filterMode)
        {
            case MyBinder.FilterMode.AND:
                {
                    if (filter.isWhite) resultingSpecification = resultingSpecification.And(isWhite);
                    if (filter.isBlue) resultingSpecification = resultingSpecification.And(isBlue);
                    if (filter.isBlack) resultingSpecification = resultingSpecification.And(isBlack);
                    if (filter.isRed) resultingSpecification = resultingSpecification.And(isRed);
                    if (filter.isGreen) resultingSpecification = resultingSpecification.And(isGreen);
                    if (filter.isColorless) resultingSpecification = resultingSpecification.And(isColorless);
                    if (filter.isMulticolored) resultingSpecification = resultingSpecification.And(isMulticolored);
                    if (filter.isArtifact) resultingSpecification = resultingSpecification.And(isArtifact);
                    if (filter.isCreature) resultingSpecification = resultingSpecification.And(isCreature);
                    if (filter.isLand) resultingSpecification = resultingSpecification.And(isLand);
                    if (filter.isInstant) resultingSpecification = resultingSpecification.And(isInstant);
                    if (filter.isSorcery) resultingSpecification = resultingSpecification.And(isSorcery);
                    if (filter.isEnchantment) resultingSpecification = resultingSpecification.And(isEnchantment);
                    if (filter.isPlaneswalker) resultingSpecification = resultingSpecification.And(isPlaneswalker);
                    if (filter.isTribal) resultingSpecification = resultingSpecification.And(isTribal);
                    break;
                }
            case MyBinder.FilterMode.OR:
                {
                    var colorSpecification = new EmptySpecification().And(new EmptySpecification());
                    if (filter.isWhite) colorSpecification = colorSpecification.Or(isWhite);
                    if (filter.isBlue) colorSpecification = colorSpecification.Or(isBlue);
                    if (filter.isBlack) colorSpecification = colorSpecification.Or(isBlack);
                    if (filter.isRed) colorSpecification = colorSpecification.Or(isRed);
                    if (filter.isGreen) colorSpecification = colorSpecification.Or(isGreen);
                    if (filter.isColorless) colorSpecification = colorSpecification.Or(isColorless);
                    if (filter.isMulticolored) colorSpecification = colorSpecification.Or(isMulticolored);

                    resultingSpecification = resultingSpecification.And(colorSpecification);

                    break;
                }
            default: break;
        }

        var finalQuery = from card in DBAgent.instance.GetCardsFromSets(DBAgent.instance.DB.sets)
                         where resultingSpecification.IsSatisfiedBy(card)
                         select card;

        currentSearchResults = finalQuery.Take(ConfigAgent.instance.SearchResultsLimit).OrderBy(card => card.name).ToList();
    }



}
