# Mikado Method to the rescue

![Mikado game sticks](images/mikado-sticks.jpg)

*[Image Source](https://pixabay.com/photos/mikado-play-puzzle-skill-colorful-1743593/)*

Test Data Builders make writing new tests faster once you have them.
Unfortunately, they take even longer to write in the first place!

That's not going to help us to test our bugs in legacy code! 

## Present the Mikado Method

The [Mikado Method](./references/The_Mikado_Method.md) is a technique to
incrementally do large refactorings, alongside feature delivery.

You'll find resource about the Mikado Method 
[here](./references/The_Mikado_Method.md) or on your room walls.

### Rapid Response Question

> As a group, what are the top 5 most important things about the the Mikado
> Method?

## Live code the beginning of the Mikado Graph here

To help you to get started, here is a demo of how to use the Mikado Method in
our particular situation.

[![Video of the beginning of the solution](./images/Testing%20legacy%20code%20with%20Mikado%20Method%20and%20Test%20Data%20Builders%20-%20YouTube.jpg)](https://www.youtube.com/watch?v=2wIb8kdxay4&feature=youtu.be)

### Video Screen Shots 

#### Mikado Graph

<details>
  <summary  markdown='span'>
  Screen-shot of the Mikado Graph from the video
  </summary>
  <img src="./images/MIkdaoScreenCapture.PNG" alt="Mikado Graph" />
</details>

#### Code Snippets 

<details>
  <summary markdown='span'>
  Code of InvoiceTest from the video
  </summary>  

##### C#

  ```csharp
  using Xunit;
  using Application.Purchase;

  namespace Application.Tests
  {
      public class InvoiceTest
      {
          [Fact]
          public void Applies_Tax_Rules_When_Computing_Total_Amount()
          {
              Invoice oneNovelUsaInvoice = AnInvoice()
                  .From(USA)
                  .With(
                      APurchasedBook().Of(ANovel().Costing(2.99)))
                  .Build();

              Assert.Equal(2.99 * 1.15  *0.98, oneNovelUsaInvoice.ComputeTotalAmount());
          }
      }
  }
  ```

</details>


<details>
  <summary markdown='span'>
  Code of NovelTestBuilder from the video
  </summary>

##### C#
  ```csharp
  using System.Collections.Generic;
  using Application.Domain.Book;
  using Application.Domain.Country;

  namespace Application.Tests
  {
      public class NovelTestBuilder
      {
          private double _price = 3.99;

          public NovelTestBuilder Costing(double price)
          {
              _price = price;
              return this;
          }

          public Novel Build()
          {
              return new Novel("Grapes with Wrath", _price, null, Language.English, new List<Genre>());
          }
      }
  }
  ```
  
</details>  

## DIY

Now that you have a better idea, grab a whiteboard, a marker, some post-its and
start creating your own mikado graph to add a test.

![Photo of a whiteboard, markers and post-its, the material needed to draw a Mikado Method](./images/workshop-material.jpg)

*[Image Source](https://pixabay.com/photos/workshop-pens-post-it-note-2209239/)*

### Delete the tests

In real life, you would

1. Fix the bugs
2. Start the mikado method to add a test with data builders

So let's delete the tests!

### Use Mikado Method to create Test Data Builders to add a test on Invoice

We'll first focus on the test on
[Invoice](../Application/Purchase/Invoice.cs). It's simpler
and achievable given the time we have.

Write your test as if you had the builders, and start to draw your mikado
graph.

Make sure your project keeps building all the time. Notice every time you have
something useful.

### Use Mikado Method to create Test Data Builders to add a test on Report Generator (advanced)

If you have the time, repeat the same exercise with the test on 
[ReportGenerator](../Application/Report/ReportGenerator.cs)

You should be able to re-use many builders you wrote before.

You might need to look for 
[other flavors of builders](./references/Test_Data_Builders.md) to finish
this test.

## Retrospective

Let's do a more thorough retrospective this time.

1- Take a few minutes to write 1 or 2 paragraphs to answer these questions:

> What are the goods and bads of combining test data builders with the 
> mikado method ?
>
> For you, what are the most important concepts and insights from this 
> training?
> 
> How do you plan to use what you’ve learned?

2- Has this workshop fulfilled your expectations?
> Go back to the notes you wrote at the beginning of the workshop   

3- Read them to your pair, and discuss

4- If you want, volunteer to share it with everyone

5- You can also check what people usually say in
[Animation Guide.md](./Animation_Guide.md)

----
[Continue...](./5_Conclusion.md)
