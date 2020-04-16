﻿using System;
using System.IO;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Color = DocumentFormat.OpenXml.Wordprocessing.Color;

using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using System.Windows.Forms;

namespace OpenXML_DLLProject
{
    public class openXmlUtilitiesWord
    {
        public static void InsertPicture(WordprocessingDocument wordprocessingDocument, string fileName)
        {
            MainDocumentPart mainPart = wordprocessingDocument.MainDocumentPart;
            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                imagePart.FeedData(stream);
            }
            AddImageToBody(wordprocessingDocument, mainPart.GetIdOfPart(imagePart));
        }

        private static void AddImageToBody(WordprocessingDocument wordDoc, string relationshipId)
        {
            // Define the reference of the image.
            var element =
                 new Drawing(
                     new DW.Inline(
                         new DW.Extent() { Cx = 990000L, Cy = 792000L },
                         new DW.EffectExtent()
                         {
                             LeftEdge = 0L,
                             TopEdge = 0L,
                             RightEdge = 0L,
                             BottomEdge = 0L
                         },
                         new DW.DocProperties()
                         {
                             Id = (UInt32Value)1U,
                             Name = "Picture 1"
                         },
                         new DW.NonVisualGraphicFrameDrawingProperties(
                             new A.GraphicFrameLocks() { NoChangeAspect = true }),
                         new A.Graphic(
                             new A.GraphicData(
                                 new PIC.Picture(
                                     new PIC.NonVisualPictureProperties(
                                         new PIC.NonVisualDrawingProperties()
                                         {
                                             Id = (UInt32Value)0U,
                                             Name = "New Bitmap Image.jpg"
                                         },
                                         new PIC.NonVisualPictureDrawingProperties()),
                                     new PIC.BlipFill(
                                         new A.Blip(
                                             new A.BlipExtensionList(
                                                 new A.BlipExtension()
                                                 {
                                                     Uri =
                                                        "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                 })
                                         )
                                         {
                                             Embed = relationshipId,
                                             CompressionState =
                                             A.BlipCompressionValues.Print
                                         },
                                         new A.Stretch(
                                             new A.FillRectangle())),
                                     new PIC.ShapeProperties(
                                         new A.Transform2D(
                                             new A.Offset() { X = 0L, Y = 0L },
                                             new A.Extents() { Cx = 990000L, Cy = 792000L }),
                                         new A.PresetGeometry(
                                             new A.AdjustValueList()
                                         )
                                         { Preset = A.ShapeTypeValues.Rectangle }))
                             )
                             { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                     )
                     {
                         DistanceFromTop = (UInt32Value)0U,
                         DistanceFromBottom = (UInt32Value)0U,
                         DistanceFromLeft = (UInt32Value)0U,
                         DistanceFromRight = (UInt32Value)0U,
                         EditId = "50D07946"
                     });

            // Append the reference to body, the element should be in a Run.
            wordDoc.MainDocumentPart.Document.Body.AppendChild(new Paragraph(new Run(element)));
        }

        public static void AddStyle(MainDocumentPart mainPart, bool isBold = false, bool isItalic = false, bool isUnderline = false, string styleId = "00", string styleName = "Default", string fontName = "Calibri", int fontSize = 12, string rgbColor = "000000")
        {
            // we have to set the properties
            RunProperties rPr = new RunProperties();
            Color color = new Color() { Val = rgbColor };
            RunFonts rFont = new RunFonts();
            rFont.Ascii = fontName;
            rPr.Append(color);
            rPr.Append(rFont);
            if (isBold) rPr.Append(new Bold());
            if (isItalic) rPr.Append(new Italic());
            if (isUnderline) rPr.Append(new Underline() { Val = UnderlineValues.Single });
            rPr.Append(new FontSize() { Val = (fontSize * 2).ToString() });

            Style style = new Style();
            style.StyleId = styleId;
            if (styleName == null || styleName.Length == 0) styleName = styleId;
            style.Append(new Name() { Val = styleName });
            style.Append(rPr); //we are adding properties previously defined

            // we have to add style that we have created to the StylePart
            StyleDefinitionsPart stylePart;
            if (mainPart.StyleDefinitionsPart == null)
            {
                stylePart = mainPart.AddNewPart<StyleDefinitionsPart>();
                stylePart.Styles = new Styles();
            }
            else stylePart = mainPart.StyleDefinitionsPart;

            stylePart.Styles.Append(style);
            stylePart.Styles.Save(); // we save the style part
        }

        public static Paragraph CreateParagraphWithStyle(string styleId, JustificationValues justification = JustificationValues.Left)
        {
            Paragraph paragraph = new Paragraph();

            ParagraphProperties pp = new ParagraphProperties();
            // we set the style
            pp.ParagraphStyleId = new ParagraphStyleId() { Val = styleId };
            // we set the alignement
            pp.Justification = new Justification() { Val = justification };
            paragraph.Append(pp);
            return paragraph;
        }

        public static void AddTextToParagraph(Paragraph paragraph, string content)
        {
            Run r = new Run();
            Text t = new Text(content);
            r.Append(t);
            paragraph.Append(r);
        }

        public static void CreateBulletNumberingPart(MainDocumentPart mainPart, string bulletChar = "-")
        {
            NumberingDefinitionsPart numberingPart =
                        mainPart.AddNewPart<NumberingDefinitionsPart>("NDPBullet");
            Numbering element =
              new Numbering(
                new AbstractNum(
                  new Level(
                    new NumberingFormat() { Val = NumberFormatValues.Bullet },
                    new LevelText() { Val = bulletChar }
                  )
                  { LevelIndex = 0 }
                )
                { AbstractNumberId = 1 },
                new NumberingInstance(
                  new AbstractNumId() { Val = 1 }
                )
                { NumberID = 1 });
            element.Save(numberingPart);
        }

        public static void CreateBulletOrNumberedList(int indentLeft, int indentHanging, List<Paragraph> paragraphs, int numberOfParagraph, string[] texts, bool isBullet = true)
        {
            int numberingLevelReference, numberingId;
            if (isBullet)
            {
                numberingLevelReference = 0;
                numberingId = 1;
            }
            else
            {
                numberingLevelReference = 1;
                numberingId = 2;
            }

            SpacingBetweenLines sbl = new SpacingBetweenLines() { After = "0" };
            Indentation indent = new Indentation() { Left = indentLeft.ToString(), Hanging = indentHanging.ToString() };
            NumberingProperties np = new NumberingProperties(
                new NumberingLevelReference() { Val = numberingLevelReference },
                new NumberingId() { Val = numberingId }
            );
            ParagraphProperties ppUnordered = new ParagraphProperties(np, sbl, indent);
            ppUnordered.ParagraphStyleId = new ParagraphStyleId() { Val = "ListParagraph" };

            for (int i = 0; i < numberOfParagraph; i++)
                InsertParagraphInList(paragraphs, ppUnordered, texts[i]);
        }

        public static void InsertParagraphInList(List<Paragraph> paragraphs, ParagraphProperties ppUnordered, string text)
        {
            Paragraph p = new Paragraph();
            p.ParagraphProperties = new ParagraphProperties(ppUnordered.OuterXml);
            p.Append(new Run(new Text(text)));
            paragraphs.Add(p);
        }

        public static Table createTable(MainDocumentPart mainPart, bool[] bolds, bool[] italics, bool[] underlines, string[] texts, JustificationValues[] justifications, int right, int cell, string rgbColor = "000000", BorderValues borderValues = BorderValues.Thick)
        {
            if (bolds.Length == italics.Length && italics.Length == underlines.Length && underlines.Length == texts.Length)
            {
                Table table = new Table();
                // set table properties
                table.AppendChild(getTableProperties(rgbColor, borderValues));

                // row 1
                int y = 0;
                for (int i = 0; i < right; i++)
                {
                    TableRow tr = new TableRow();

                    for (int j = 0; j < cell; j++)
                    {
                        AddStyle(mainPart, bolds[y], italics[y], underlines[y], $"0{y}", $"Table{y}");
                        TableCell tc = new TableCell();
                        Paragraph p = CreateParagraphWithStyle($"0{y}", justifications[y]);
                        AddTextToParagraph(p, texts[y]);
                        tc.Append(p);
                        tr.Append(tc);
                        y++;
                    }

                    table.Append(tr);
                }
                return table;
            }
            else
                MessageBox.Show("Errore nella tabella! Numero di stili o testi diverso dal numero di paragrafi");
            return null;
        }

        private static TableProperties getTableProperties(string rgbColor, BorderValues borderValues)
        {
            TableProperties tblProperties = new TableProperties();
            TableBorders tblBorders = new TableBorders();

            TopBorder topBorder = new TopBorder();
            topBorder.Val = new EnumValue<BorderValues>(borderValues);
            topBorder.Color = rgbColor;
            tblBorders.AppendChild(topBorder);

            BottomBorder bottomBorder = new BottomBorder();
            bottomBorder.Val = new EnumValue<BorderValues>(borderValues);
            bottomBorder.Color = rgbColor;
            tblBorders.AppendChild(bottomBorder);

            RightBorder rightBorder = new RightBorder();
            rightBorder.Val = new EnumValue<BorderValues>(borderValues);
            rightBorder.Color = rgbColor;
            tblBorders.AppendChild(rightBorder);

            LeftBorder leftBorder = new LeftBorder();
            leftBorder.Val = new EnumValue<BorderValues>(borderValues);
            leftBorder.Color = rgbColor;
            tblBorders.AppendChild(leftBorder);

            InsideHorizontalBorder insideHBorder = new InsideHorizontalBorder();
            insideHBorder.Val = new EnumValue<BorderValues>(borderValues);
            insideHBorder.Color = rgbColor;
            tblBorders.AppendChild(insideHBorder);

            InsideVerticalBorder insideVBorder = new InsideVerticalBorder();
            insideVBorder.Val = new EnumValue<BorderValues>(borderValues);
            insideVBorder.Color = rgbColor;
            tblBorders.AppendChild(insideVBorder);

            tblProperties.AppendChild(tblBorders);

            return tblProperties;
        }
    }
}
