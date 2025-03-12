﻿namespace ViteCent.Core;

/// <summary>
/// </summary>
public class BasePinYinHash
{
    /// <summary>
    /// </summary>
    private static short[][] _hashes =
    [
        [23, 70, 96, 128, 154, 165, 172, 195],
        [25, 35, 87, 108, 120, 128, 132, 137, 168, 180, 325, 334, 336, 353, 361, 380],
        [23, 34, 46, 81, 82, 87, 134, 237, 255, 288, 317, 322, 354, 359],
        [7, 11, 37, 49, 53, 56, 131, 132, 146, 176, 315, 372],
        [11, 69, 73, 87, 96, 103, 159, 175, 195, 296, 298, 359, 361],
        [57, 87, 115, 126, 149, 244, 282, 298, 308, 345, 355],
        [19, 37, 117, 118, 141, 154, 196, 216, 267, 301, 327, 333, 337, 347],
        [4, 11, 59, 61, 62, 87, 119, 169, 183, 198, 262, 334, 362, 380],
        [37, 135, 167, 170, 246, 250, 334, 341, 351, 354, 386, 390, 398],
        [5, 6, 52, 55, 76, 146, 165, 244, 256, 266, 300, 318, 331],
        [6, 71, 94, 129, 137, 141, 169, 179, 225, 226, 235, 248, 289, 290, 333, 345, 391],
        [0, 33, 37, 62, 90, 131, 205, 246, 268, 343, 349, 380],
        [31, 62, 85, 115, 117, 150, 159, 167, 171, 204, 215, 252, 343],
        [69, 81, 98, 140, 165, 195, 239, 240, 259, 265, 329, 368, 375, 392, 393],
        [13, 81, 82, 123, 132, 144, 154, 165, 334, 336, 345, 348, 349, 355, 367, 377, 383],
        [31, 32, 44, 57, 76, 83, 87, 129, 151, 172, 176, 183, 184, 193, 221, 235, 285, 288, 305],
        [10, 14, 60, 76, 85, 97, 115, 125, 128, 130, 286, 288, 301, 313, 382],
        [62, 128, 136, 175, 211, 240, 254, 273, 274, 317, 330, 344, 349, 360, 380],
        [29, 47, 52, 116, 126, 127, 130, 133, 191, 284, 288, 306, 353, 361, 383],
        [1, 15, 25, 67, 83, 90, 117, 121, 150, 228, 308, 324, 336, 351, 386],
        [34, 37, 67, 101, 103, 117, 127, 165, 168, 254, 267, 272, 274, 288, 305, 310, 323, 329, 333, 358, 378],
        [5, 74, 103, 135, 163, 165, 171, 244, 262, 266, 334, 352, 390, 397],
        [4, 17, 95, 125, 165, 186, 203, 221, 252, 282, 317, 333, 339, 348, 351, 353],
        [74, 79, 81, 84, 92, 110, 116, 117, 131, 132, 154, 199, 241, 251, 300, 306, 349, 359, 383, 387],
        [40, 83, 127, 144, 161, 188, 249, 288, 344, 382, 388],
        [8, 55, 61, 76, 85, 98, 111, 127, 186, 230, 241, 247, 267, 287, 327, 341, 344, 347, 359, 364],
        [20, 59, 69, 80, 117, 129, 176, 186, 191, 237, 275, 289, 309, 338, 375, 380],
        [5, 15, 25, 35, 40, 129, 174, 236, 274, 337, 347],
        [14, 22, 47, 56, 87, 120, 129, 144, 155, 160, 237, 283, 284, 309, 327, 337, 365, 372],
        [1, 14, 47, 132, 198, 254, 255, 300, 310, 335, 336, 372],
        [2, 36, 64, 96, 125, 176, 184, 190, 211, 271, 308, 315, 367],
        [20, 76, 79, 81, 110, 117, 120, 129, 182, 192, 235, 353, 378],
        [37, 83, 88, 92, 111, 127, 243, 303, 324, 325, 348, 353, 359, 371, 377],
        [5, 87, 90, 124, 127, 180, 259, 288, 290, 302, 312, 313, 324, 332],
        [55, 62, 89, 98, 108, 132, 168, 240, 248, 322, 325, 327, 347, 353, 391, 396],
        [4, 8, 13, 35, 37, 39, 41, 64, 111, 174, 212, 245, 248, 251, 263, 288, 335, 373, 375],
        [10, 39, 93, 110, 168, 227, 228, 254, 288, 336, 378, 381],
        [75, 92, 122, 176, 198, 211, 214, 283, 334, 353, 359, 379, 386],
        [5, 8, 13, 19, 57, 87, 104, 125, 130, 176, 202, 249, 252, 290, 309, 391],
        [88, 132, 173, 176, 235, 247, 253, 292, 324, 328, 339, 359],
        [19, 32, 61, 84, 87, 118, 120, 125, 129, 132, 181, 190, 288, 290, 331, 355, 359, 366],
        [13, 25, 46, 126, 140, 157, 165, 225, 226, 252, 288, 304, 327, 353, 378],
        [12, 14, 26, 56, 72, 95, 131, 132, 134, 142, 253, 298, 337, 361, 391],
        [4, 18, 37, 49, 87, 93, 196, 225, 226, 246, 248, 250, 255, 310, 354, 358],
        [64, 87, 110, 111, 128, 135, 151, 165, 177, 188, 191, 268, 312, 334, 352, 354, 357, 371],
        [10, 17, 19, 30, 40, 48, 81, 97, 125, 129, 130, 182, 234, 305, 328, 393],
        [13, 69, 80, 114, 192, 200, 235, 343, 345, 353, 354, 360, 374, 378, 383],
        [83, 87, 94, 105, 107, 124, 144, 153, 219, 290, 298, 324, 349, 358, 367],
        [10, 36, 142, 169, 221, 232, 241, 246, 346, 347, 375, 383, 390],
        [26, 104, 126, 143, 176, 186, 241, 247, 250, 318, 320, 333, 360],
        [66, 92, 116, 148, 191, 215, 254, 333, 334, 335, 336, 351, 353, 358, 380],
        [9, 37, 55, 56, 76, 79, 90, 111, 122, 124, 161, 192, 247, 313, 353, 359, 374],
        [17, 30, 34, 56, 64, 68, 90, 125, 151, 168, 176, 188, 286, 333, 338, 360],
        [26, 143, 173, 182, 190, 194, 246, 284, 286, 328, 333, 355, 357, 360, 362, 363, 377, 380],
        [1, 13, 87, 122, 168, 171, 186, 201, 297, 328, 349, 352, 380],
        [18, 39, 61, 88, 98, 123, 129, 131, 148, 162, 165, 243, 285, 314, 340, 349, 360, 377, 378],
        [67, 98, 117, 118, 122, 128, 156, 174, 184, 207, 244, 250, 330, 335, 342, 372, 375],
        [13, 38, 63, 160, 180, 185, 189, 190, 219, 248, 253, 275, 297, 318, 355],
        [1, 44, 47, 93, 107, 172, 235, 276, 281, 287, 290, 306, 333, 334, 337, 347, 353, 376],
        [13, 15, 32, 125, 127, 157, 165, 176, 236, 344, 350, 381],
        [47, 65, 93, 134, 159, 174, 218, 282, 318, 336, 358, 373, 379],
        [7, 17, 40, 66, 102, 141, 154, 159, 165, 172, 174, 177, 328, 329, 334, 348, 379, 382],
        [4, 34, 36, 76, 79, 122, 127, 138, 176, 241, 267, 309, 334, 367, 382],
        [9, 17, 33, 46, 90, 103, 125, 138, 144, 157, 185, 198, 224, 250, 260, 291, 326, 343, 349, 377, 381],
        [29, 31, 53, 58, 134, 138, 193, 287, 305, 308, 333, 334],
        [13, 64, 83, 93, 129, 192, 227, 244, 397],
        [7, 8, 14, 78, 85, 103, 138, 175, 176, 200, 203, 234, 301, 313, 361],
        [13, 75, 87, 111, 244, 253, 288, 321, 339, 341, 357, 395],
        [4, 14, 42, 64, 69, 108, 110, 117, 122, 131, 159, 163, 188, 198, 200, 206, 244, 292, 300, 354, 390],
        [14, 37, 73, 87, 129, 135, 144, 176, 182, 300, 346, 352, 380, 383],
        [23, 50, 87, 143, 171, 186, 191, 223, 290, 333, 334, 364, 378, 380, 388, 391, 393],
        [5, 14, 23, 36, 62, 71, 76, 95, 99, 128, 176, 211, 229, 357],
        [12, 33, 47, 70, 81, 90, 97, 119, 122, 131, 189, 190, 191, 235, 244, 253, 320, 350, 359],
        [10, 13, 23, 93, 110, 120, 135, 171, 195, 250, 293, 298, 329, 344, 354],
        [13, 29, 37, 163, 169, 200, 211, 214, 217, 236, 246, 249, 282, 327, 349, 353, 362, 372],
        [5, 13, 23, 41, 57, 62, 76, 89, 111, 135, 195, 234, 248, 314, 334, 341, 349, 380],
        [17, 35, 57, 117, 121, 206, 235, 243, 265, 329, 358, 374],
        [13, 28, 41, 55, 69, 101, 103, 126, 138, 198, 267, 276, 288, 313, 334, 335, 339, 354, 376, 383, 394],
        [11, 13, 19, 36, 38, 58, 75, 124, 232, 235, 265, 286, 298, 330, 333, 359],
        [4, 19, 25, 43, 110, 125, 165, 331, 334, 341, 349, 355, 372],
        [40, 55, 64, 70, 117, 126, 127, 135, 160, 172, 173, 186, 270, 318, 338, 344, 378],
        [122, 176, 198, 238, 246, 284, 286, 290, 318, 329, 337, 381, 394],
        [23, 36, 37, 44, 117, 124, 198, 204, 233, 248, 282, 288, 297, 314, 332, 336, 388],
        [15, 33, 54, 64, 75, 85, 115, 127, 165, 196, 229, 237, 254, 307, 327, 335, 349, 383],
        [22, 87, 121, 127, 161, 180, 248, 250, 276, 313, 324, 347, 349, 355, 357, 359],
        [14, 48, 67, 88, 130, 131, 172, 188, 195, 203, 267, 282, 333, 339, 350, 392],
        [22, 31, 37, 98, 118, 132, 135, 137, 142, 151, 243, 244, 282, 305, 333, 349, 350, 351, 353, 358, 374],
        [15, 42, 67, 75, 125, 134, 189, 255, 261, 309, 334, 350, 380, 382],
        [10, 39, 87, 97, 105, 109, 125, 137, 225, 226, 253, 329, 341, 354, 363, 372],
        [5, 17, 42, 64, 80, 111, 120, 169, 175, 206, 237, 267, 288, 290, 324, 351, 364, 390],
        [
            3, 33, 55, 75, 91, 97, 103, 132, 187, 220, 232, 234, 240, 288, 301, 330, 336, 337, 338, 340, 359, 374, 380,
            382
        ],
        [13, 87, 98, 125, 126, 127, 128, 250, 330, 341, 353, 360, 374, 382, 391],
        [59, 66, 75, 125, 135, 172, 192, 230, 231, 255, 256, 276, 300, 306, 339, 349, 353, 390],
        [25, 36, 56, 90, 107, 125, 127, 142, 165, 195, 244, 246, 319, 347, 355, 375, 380],
        [2, 33, 35, 36, 72, 74, 87, 92, 111, 131, 145, 176, 244, 248, 282, 333, 355, 359],
        [5, 39, 127, 134, 137, 200, 240, 283, 284, 343, 344, 372],
        [9, 32, 37, 80, 96, 104, 110, 117, 154, 176, 244, 297, 298, 339, 353, 374, 381],
        [38, 51, 64, 76, 80, 93, 96, 134, 150, 173, 275, 290, 340, 347, 359, 363, 380],
        [55, 89, 111, 126, 157, 159, 162, 182, 188, 244, 253, 280, 334, 359, 384, 398],
        [59, 64, 75, 81, 97, 105, 115, 125, 155, 198, 248, 262, 319, 323, 376],
        [
            13, 41, 76, 125, 127, 130, 134, 135, 159, 167, 183, 229, 230, 240, 246, 308, 319, 329, 333, 334, 340, 344,
            363, 382
        ],
        [8, 13, 19, 31, 70, 76, 79, 96, 127, 153, 163, 165, 184, 227, 230, 247, 255, 336, 337, 348, 353, 357, 361, 362],
        [71, 87, 111, 121, 130, 142, 150, 160, 175, 224, 248, 314, 336, 353, 357, 359],
        [67, 84, 101, 130, 287, 288, 332, 333, 359, 361, 377],
        [34, 52, 90, 100, 125, 135, 165, 173, 320, 341, 352, 359, 382, 392],
        [13, 18, 39, 55, 62, 87, 248, 255, 290, 327, 349, 353, 355, 360, 383],
        [1, 9, 12, 29, 32, 36, 82, 139, 140, 149, 153, 165, 167, 180, 185, 231, 241, 244, 274, 299, 309, 329, 355, 362],
        [48, 66, 98, 107, 120, 122, 125, 135, 190, 195, 198, 215, 253, 256, 280, 282, 307, 320, 334, 349, 353, 355],
        [1, 7, 13, 25, 64, 98, 139, 144, 166, 176, 206, 236, 262, 330, 362],
        [37, 55, 116, 123, 125, 131, 165, 234, 266, 276, 328, 329, 342, 349, 353, 359, 391],
        [126, 137, 191, 215, 239, 288, 290, 321, 324, 333, 334, 338, 349, 353, 362, 379],
        [50, 57, 87, 93, 98, 115, 134, 148, 174, 229, 251, 260, 285, 298, 313, 348, 349, 350],
        [5, 13, 31, 45, 69, 81, 108, 122, 127, 160, 165, 176, 179, 237, 244, 301, 316, 352, 360],
        [5, 87, 95, 98, 101, 132, 135, 159, 167, 190, 203, 217, 234, 235, 247, 289, 333, 341, 343, 352],
        [22, 56, 66, 85, 87, 93, 126, 127, 163, 230, 243, 248, 254, 280, 301, 305, 334, 357],
        [13, 19, 53, 59, 76, 91, 117, 122, 195, 298, 303, 309, 337, 345, 398],
        [9, 54, 84, 107, 125, 127, 135, 144, 156, 173, 176, 202, 215, 231, 234, 246, 266, 282, 335, 336, 347, 351, 374],
        [11, 15, 30, 31, 40, 57, 58, 87, 88, 113, 186, 244, 245, 256, 308, 334, 377],
        [62, 111, 176, 196, 228, 231, 288, 294, 302, 306, 350, 353, 375, 378, 392],
        [119, 131, 133, 154, 161, 179, 198, 232, 234, 265, 301, 314, 344, 353, 378],
        [67, 84, 123, 172, 175, 176, 182, 229, 290, 359, 360, 375, 383, 393],
        [33, 36, 39, 102, 116, 136, 137, 208, 234, 256, 307, 329, 341, 347, 376, 380],
        [13, 27, 32, 80, 95, 108, 131, 165, 167, 180, 190, 200, 235, 241, 244, 323, 330, 339, 372],
        [1, 18, 37, 62, 67, 82, 85, 118, 125, 147, 159, 169, 174, 243, 284, 307, 313, 318, 355, 391, 396],
        [10, 87, 91, 135, 169, 176, 215, 246, 267, 282, 295, 320, 345, 353, 380],
        [2, 11, 13, 29, 90, 124, 131, 132, 170, 174, 176, 229, 246, 258, 298, 336, 344, 349],
        [14, 37, 42, 71, 128, 152, 185, 218, 288, 304, 315, 353, 362, 380, 391],
        [17, 20, 36, 73, 93, 128, 163, 194, 211, 217, 282, 290, 320, 354, 383],
        [9, 26, 32, 101, 127, 169, 178, 183, 191, 236, 244, 310, 330, 336, 345, 353, 360, 372, 380, 394],
        [7, 13, 64, 78, 81, 90, 115, 133, 164, 169, 244, 246, 269, 278, 290, 292, 310, 320, 353, 360, 364, 366, 380],
        [8, 65, 81, 84, 91, 126, 129, 158, 183, 184, 194, 254, 262, 333, 334, 339, 351, 363, 382],
        [44, 87, 96, 97, 125, 161, 173, 177, 183, 188, 189, 209, 235, 288, 315, 334, 351],
        [50, 56, 60, 62, 67, 71, 105, 149, 154, 158, 164, 167, 185, 221, 285, 288, 308, 337, 344, 353],
        [6, 10, 37, 62, 74, 79, 81, 128, 139, 154, 167, 198, 228, 244, 267, 290, 302, 368, 394],
        [6, 30, 35, 36, 62, 65, 71, 112, 153, 163, 167, 180, 186, 195, 249, 286, 303, 329, 334],
        [158, 241, 282, 324, 332, 334, 351, 353, 363, 365],
        [17, 89, 117, 144, 165, 180, 185, 198, 229, 244, 290, 334, 335, 380],
        [20, 32, 45, 57, 64, 66, 120, 135, 144, 176, 192, 244, 297, 301, 354, 381],
        [1, 7, 35, 62, 74, 122, 159, 170, 172, 238, 239, 307, 308, 338, 349, 350, 359, 366, 368, 375, 382, 383],
        [7, 9, 23, 66, 92, 103, 111, 135, 182, 203, 246, 247, 265, 285, 288, 303, 317, 329, 348],
        [13, 39, 74, 87, 127, 135, 144, 193, 212, 243, 270, 290, 303, 315, 375, 376],
        [33, 36, 40, 59, 101, 120, 127, 244, 285, 287, 309, 339, 391],
        [4, 10, 39, 195, 268, 284, 336, 354, 359, 375, 381],
        [39, 42, 62, 79, 83, 84, 101, 109, 132, 138, 202, 215, 277, 353, 358, 359],
        [10, 39, 46, 73, 84, 87, 132, 170, 192, 219, 232, 246, 288, 320, 337],
        [10, 12, 56, 87, 91, 101, 132, 227, 254, 301, 303, 333, 343, 347, 351],
        [7, 8, 15, 18, 82, 105, 130, 232, 250, 290, 316, 332, 348, 350],
        [36, 109, 110, 125, 154, 191, 193, 246, 265, 348, 349, 350, 378, 383],
        [12, 16, 45, 57, 87, 92, 101, 105, 129, 130, 155, 167, 218, 292, 293, 327, 349, 354, 361],
        [30, 59, 64, 121, 125, 149, 163, 188, 212, 250, 348, 350, 351, 352, 353, 378, 380],
        [1, 69, 130, 138, 194, 200, 239, 260, 264, 357, 380, 381, 382, 396],
        [7, 10, 19, 40, 57, 61, 125, 137, 141, 212, 239, 251, 310, 333, 347, 359, 380, 383],
        [20, 28, 50, 97, 109, 134, 157, 162, 184, 199, 244, 246, 286, 352, 353, 360, 373, 380],
        [35, 62, 87, 96, 122, 127, 136, 142, 148, 155, 165, 186, 196, 227, 354, 380, 388],
        [81, 82, 101, 115, 125, 200, 243, 313, 351, 359, 367],
        [7, 19, 40, 61, 107, 108, 124, 154, 161, 244, 309, 329, 345, 379, 394],
        [10, 27, 48, 66, 75, 103, 116, 122, 128, 221, 228, 319, 322, 350, 377, 398],
        [2, 64, 74, 117, 130, 165, 172, 180, 191, 218, 221, 288, 299, 325, 347, 353, 355, 360],
        [5, 76, 79, 87, 106, 111, 137, 168, 180, 235, 243, 288, 315, 321, 338, 344, 348, 378, 382, 383],
        [0, 29, 31, 37, 40, 50, 88, 100, 129, 134, 137, 144, 174, 186, 203, 254, 310, 313, 329, 341, 359, 364],
        [69, 70, 71, 96, 115, 121, 130, 157, 159, 200, 230, 246, 250, 299, 318, 324, 353, 359, 380, 391],
        [7, 90, 95, 116, 127, 128, 135, 137, 141, 154, 161, 254, 330, 359, 379, 388],
        [10, 14, 56, 91, 108, 125, 130, 167, 211, 228, 246, 258, 280, 306, 324, 333, 336, 338, 379],
        [4, 5, 14, 57, 85, 98, 125, 135, 136, 176, 254, 334, 336, 337, 351, 358, 362, 379, 383],
        [1, 4, 13, 18, 19, 32, 50, 60, 62, 87, 117, 176, 211, 251, 329, 343, 359],
        [38, 56, 94, 103, 117, 125, 129, 144, 159, 176, 244, 251, 253, 324, 345, 353, 386, 390],
        [4, 22, 38, 47, 59, 64, 82, 97, 110, 135, 153, 176, 235, 236, 241, 287, 288, 303, 333, 347, 358, 359, 361],
        [2, 5, 20, 52, 97, 125, 127, 132, 135, 137, 174, 188, 191, 243, 288, 310, 334, 346, 348, 349, 362, 372, 378],
        [19, 35, 55, 98, 125, 131, 134, 147, 153, 246, 255, 390],
        [5, 59, 62, 129, 136, 153, 198, 225, 235, 239, 254, 295, 334, 338, 341, 359, 361],
        [8, 13, 51, 94, 121, 122, 125, 126, 129, 240, 272, 290, 297, 323, 352, 358, 376, 391, 395],
        [6, 111, 116, 122, 125, 131, 135, 164, 175, 200, 212, 221, 267, 287, 319, 328, 334, 344, 378],
        [83, 108, 143, 172, 176, 192, 198, 246, 262, 286, 287, 308, 338, 340, 343, 348, 353, 367, 380, 383],
        [39, 82, 92, 118, 126, 128, 144, 171, 211, 234, 244, 253, 328, 333, 339, 357, 359, 380],
        [37, 62, 64, 81, 97, 122, 125, 127, 137, 211, 246, 344, 360],
        [7, 29, 62, 67, 69, 81, 87, 107, 132, 151, 160, 229, 244, 284, 285, 317, 358, 387, 390],
        [13, 75, 76, 83, 87, 154, 165, 190, 212, 258, 285, 308, 309, 316, 320, 332, 336, 340, 352, 353, 354, 358, 383],
        [9, 19, 29, 46, 122, 125, 127, 130, 170, 171, 174, 180, 182, 232, 282, 290, 359, 362, 367],
        [13, 40, 71, 98, 101, 116, 125, 127, 169, 172, 175, 283, 288, 309, 311, 313, 323, 334, 353, 391],
        [3, 9, 70, 104, 118, 173, 200, 219, 246, 262, 288, 297, 309, 328, 329, 334, 341, 353],
        [32, 89, 93, 131, 132, 142, 199, 200, 214, 246, 287, 298, 307, 339, 348, 349, 357, 358, 368, 372, 391],
        [103, 134, 159, 176, 186, 235, 261, 276, 282, 290, 301, 317, 329, 345, 356],
        [10, 59, 125, 129, 130, 192, 217, 283, 318, 343, 345, 349, 353, 380, 383, 392],
        [19, 76, 79, 102, 107, 126, 155, 161, 180, 253, 288, 289, 290, 314, 329, 333, 334, 360, 368, 378, 394],
        [12, 92, 98, 105, 137, 149, 172, 196, 198, 244, 260, 262, 282, 298, 329, 345, 353, 368, 390],
        [31, 39, 79, 83, 121, 125, 167, 171, 186, 198, 288, 303, 306, 334, 337, 376],
        [13, 20, 36, 57, 98, 108, 114, 165, 171, 225, 226, 262, 269, 305, 309, 351, 377, 389],
        [13, 51, 71, 93, 110, 129, 130, 156, 165, 170, 173, 183, 191, 200, 211, 212, 255, 266, 299, 301, 329, 336, 348],
        [31, 56, 97, 122, 125, 129, 160, 188, 202, 204, 206, 225, 235, 247, 254, 255, 288, 334, 350, 362, 365, 367],
        [9, 32, 37, 70, 75, 87, 88, 96, 125, 130, 162, 163, 168, 169, 257, 285, 308, 310, 337, 373, 392],
        [
            18, 40, 42, 47, 73, 76, 85, 105, 108, 125, 130, 132, 134, 167, 191, 284, 310, 311, 344, 358, 361, 374, 378,
            379
        ],
        [5, 19, 29, 31, 48, 65, 98, 129, 131, 143, 165, 171, 172, 196, 198, 277, 296, 311, 317, 327, 351, 380],
        [51, 69, 96, 98, 117, 123, 130, 131, 148, 161, 168, 172, 176, 184, 202, 324, 332, 336, 348, 392],
        [1, 20, 37, 57, 70, 76, 79, 87, 165, 176, 234, 251, 333, 388],
        [8, 13, 134, 135, 153, 165, 169, 193, 195, 255, 273, 337, 348, 359, 360, 382, 391],
        [2, 14, 53, 71, 83, 127, 136, 144, 149, 208, 234, 235, 293, 301, 347, 352],
        [20, 40, 42, 95, 135, 141, 165, 199, 250, 290, 299, 308, 337, 338, 350, 353, 354, 355, 358, 380],
        [13, 19, 33, 35, 36, 49, 85, 121, 122, 127, 137, 158, 165, 282, 303, 320, 328, 334, 365, 367, 374],
        [17, 37, 123, 126, 127, 139, 140, 143, 167, 185, 192, 235, 254, 275, 315, 340, 349, 353, 362],
        [57, 72, 127, 159, 163, 165, 176, 199, 215, 218, 238, 254, 284, 288, 336, 339, 347, 352, 380, 395],
        [54, 69, 81, 101, 114, 121, 165, 206, 236, 313, 332, 338, 349, 358, 360, 362, 377],
        [29, 37, 43, 120, 127, 176, 193, 244, 246, 254, 284, 288, 336, 339, 372],
        [36, 56, 85, 122, 125, 126, 154, 232, 282, 308, 314, 315, 324, 336, 353, 359, 382],
        [7, 99, 104, 117, 124, 125, 143, 176, 239, 298, 318, 383],
        [13, 20, 71, 90, 108, 122, 176, 186, 214, 231, 247, 262, 267, 280, 286, 300, 332, 358, 377, 380, 385, 390, 393],
        [31, 65, 75, 79, 85, 91, 109, 110, 120, 159, 229, 235, 288, 298, 347, 355, 359, 379, 381],
        [38, 75, 82, 90, 99, 202, 248, 265, 324, 329, 350, 354, 355, 365],
        [7, 15, 72, 90, 117, 125, 140, 144, 171, 198, 269, 271, 282, 305, 325, 338, 343, 353],
        [13, 14, 20, 29, 37, 42, 45, 47, 165, 184, 244, 329, 341, 347, 372],
        [31, 36, 82, 99, 149, 154, 173, 182, 185, 200, 217, 251, 298, 329, 332, 333, 349, 353, 354, 355, 377, 383],
        [32, 44, 45, 52, 93, 97, 108, 114, 120, 144, 155, 172, 236, 240, 267, 272, 282, 288, 329, 333, 334, 343, 381],
        [35, 55, 57, 62, 95, 96, 98, 127, 131, 177, 262, 317, 318, 357, 359, 380, 388],
        [22, 24, 68, 103, 115, 119, 120, 125, 128, 156, 162, 184, 186, 235, 244, 327, 353, 358, 378, 380, 393],
        [29, 37, 62, 67, 81, 83, 93, 104, 110, 129, 132, 142, 172, 274, 298, 354, 380],
        [19, 45, 66, 87, 104, 108, 118, 155, 170, 176, 234, 286, 310, 313, 327, 329, 333, 347, 358, 368, 380, 383, 386],
        [10, 14, 32, 83, 96, 131, 165, 180, 205, 211, 249, 255, 286, 288, 292, 299, 312, 336, 338, 349, 368, 375],
        [2, 13, 48, 75, 85, 98, 116, 125, 126, 128, 135, 136, 151, 188, 195, 243, 280, 289, 333, 339, 349, 378, 382],
        [9, 19, 39, 45, 87, 106, 117, 125, 126, 127, 154, 165, 202, 211, 256, 309, 360, 397, 398],
        [14, 21, 65, 76, 87, 93, 97, 105, 131, 177, 212, 254, 294, 336, 349, 359, 381],
        [36, 55, 65, 70, 87, 93, 96, 98, 108, 127, 254, 337, 352, 359, 375, 380],
        [22, 42, 62, 82, 131, 132, 136, 158, 168, 196, 267, 305, 336],
        [45, 69, 74, 75, 81, 120, 123, 126, 127, 130, 150, 171, 191, 194, 313, 339, 368, 378, 379, 389, 398],
        [35, 43, 85, 98, 122, 131, 135, 176, 189, 250, 259, 277, 288, 303, 333, 336, 345, 376, 381, 387],
        [1, 6, 34, 87, 115, 129, 131, 202, 235, 252, 256, 263, 317, 328, 349, 372, 391],
        [3, 18, 42, 48, 84, 90, 92, 138, 193, 227, 288, 310, 315, 353, 375],
        [2, 10, 31, 66, 124, 145, 240, 314, 334],
        [32, 38, 84, 141, 165, 188, 193, 212, 346, 359, 379, 380],
        [10, 75, 81, 96, 111, 140, 179, 298, 309, 353, 357, 359, 380, 396],
        [2, 34, 121, 127, 132, 134, 184, 234, 244, 251, 262, 290, 308, 359, 380],
        [17, 24, 93, 172, 186, 198, 218, 234, 239, 250, 252, 255, 307, 309, 325, 334, 354, 359],
        [14, 18, 45, 50, 131, 174, 211, 237, 252, 267, 309, 334, 348, 351, 377, 391],
        [32, 61, 87, 97, 125, 126, 132, 184, 249, 252, 273, 284, 288, 339, 383, 398],
        [76, 81, 87, 127, 147, 161, 163, 199, 206, 306, 329, 340, 349, 353, 360, 383],
        [14, 16, 76, 87, 101, 169, 188, 243, 246, 251, 253, 269, 298, 355, 375, 380],
        [32, 79, 87, 103, 117, 125, 127, 177, 244, 301, 305, 317, 333, 338, 340, 342, 391],
        [4, 67, 76, 121, 127, 130, 140, 158, 165, 186, 193, 251, 301, 303, 330, 336],
        [11, 76, 83, 84, 87, 214, 248, 276, 299, 311, 320, 329, 332, 335, 371],
        [2, 4, 19, 40, 42, 71, 98, 119, 121, 137, 167, 262, 288, 295, 306, 339, 350, 382],
        [14, 40, 54, 90, 125, 129, 132, 146, 147, 165, 169, 176, 190, 253, 284, 303, 307, 316, 339, 342, 359, 389],
        [
            47, 59, 71, 103, 125, 126, 129, 130, 200, 206, 240, 254, 276, 282, 299, 303, 307, 318, 320, 336, 338, 357,
            362, 380, 387, 392
        ],
        [4, 22, 58, 102, 113, 115, 153, 167, 188, 212, 262, 286, 305, 333, 348, 354, 360, 371, 379, 386],
        [5, 6, 56, 61, 108, 128, 129, 164, 165, 177, 182, 225, 226, 235, 244, 246, 249, 310, 333, 348, 349, 381, 391],
        [18, 32, 33, 53, 56, 176, 186, 199, 200, 244, 246, 248, 259, 285, 289, 306, 358, 371, 373, 375, 379],
        [40, 43, 70, 76, 83, 84, 90, 93, 101, 125, 159, 204, 276, 282, 304, 320, 339, 351, 353, 367, 391],
        [14, 19, 59, 71, 76, 87, 93, 97, 105, 111, 120, 121, 122, 154, 171, 211, 231, 244, 286, 288, 341, 351],
        [10, 56, 65, 72, 92, 108, 123, 129, 212, 258, 329, 353, 359],
        [5, 76, 124, 127, 161, 172, 188, 244, 250, 266, 290, 318, 347, 351, 369, 382, 391, 395],
        [1, 33, 86, 120, 121, 130, 154, 162, 173, 192, 241, 244, 262, 338, 339, 343, 353, 380, 390],
        [1, 15, 22, 54, 57, 85, 126, 127, 176, 188, 248, 305, 332, 347, 349, 358, 367],
        [91, 111, 122, 125, 130, 178, 190, 224, 225, 226, 235, 286, 308, 329, 334, 345, 346, 349, 358, 362, 367],
        [16, 26, 51, 54, 84, 85, 98, 120, 272, 319, 349, 359, 360, 362, 377, 391, 398],
        [73, 85, 102, 109, 128, 153, 171, 184, 248, 249, 256, 298, 300, 335, 338, 340, 355, 370],
        [9, 108, 122, 131, 164, 168, 173, 176, 195, 218, 235, 286, 341, 350, 353, 358, 375, 377],
        [25, 62, 125, 140, 165, 173, 200, 225, 226, 243, 283, 286, 329, 343, 357, 366, 377],
        [
            10, 35, 58, 64, 98, 103, 125, 127, 129, 135, 141, 165, 169, 175, 189, 244, 258, 259, 306, 331, 333, 378,
            380, 391
        ],
        [54, 87, 89, 99, 116, 125, 129, 221, 246, 269, 324, 335, 348, 351],
        [85, 90, 103, 115, 131, 134, 165, 207, 282, 307, 313, 328, 346, 349, 380, 383, 387, 398],
        [10, 40, 74, 84, 160, 239, 253, 272, 282, 333, 344, 351, 359, 360, 379],
        [32, 38, 54, 74, 76, 117, 163, 171, 176, 217, 227, 250, 251, 280, 329, 330, 350, 378],
        [13, 20, 40, 107, 129, 135, 154, 158, 161, 163, 179, 206, 281, 315, 325, 351, 355, 359, 397],
        [0, 4, 37, 49, 62, 98, 117, 129, 177, 244, 285, 289, 306, 338, 360, 381],
        [36, 38, 43, 61, 71, 87, 120, 128, 172, 200, 235, 247, 251, 282, 299, 329, 341, 352, 355],
        [43, 71, 83, 85, 108, 117, 118, 121, 133, 138, 165, 206, 231, 254, 290, 291, 335, 336, 359, 362, 377],
        [29, 32, 71, 103, 122, 125, 198, 224, 244, 285, 303, 333, 335, 337],
        [54, 55, 82, 87, 101, 108, 127, 229, 230, 269, 290, 306, 349, 353],
        [9, 117, 126, 137, 154, 165, 167, 186, 192, 229, 277, 283, 301, 317, 365, 367, 372, 378],
        [4, 11, 19, 47, 51, 92, 110, 132, 137, 140, 290, 298, 361, 377, 379],
        [23, 83, 98, 134, 165, 170, 186, 190, 253, 269, 308, 322, 327, 332, 335, 344, 398],
        [60, 83, 111, 129, 173, 176, 186, 232, 306, 327, 329, 349, 355],
        [25, 31, 40, 56, 72, 95, 126, 144, 149, 161, 173, 240, 262, 332, 333, 356, 368, 391, 394],
        [91, 127, 134, 144, 155, 158, 161, 232, 251, 280, 287, 353, 380, 394],
        [37, 43, 57, 84, 87, 149, 175, 288, 330, 380],
        [8, 9, 83, 97, 120, 128, 158, 171, 193, 232, 287, 308, 309, 334, 355],
        [39, 40, 62, 82, 94, 98, 101, 144, 147, 205, 290, 333, 339, 353, 372, 397],
        [10, 20, 38, 125, 135, 138, 168, 180, 191, 203, 231, 250, 280, 301, 328, 345, 388],
        [44, 54, 64, 87, 117, 122, 127, 154, 234, 239, 244, 298, 329, 378, 383],
        [13, 62, 70, 97, 121, 176, 244, 267, 282, 318, 324, 334, 341, 353, 386, 388],
        [40, 89, 91, 117, 125, 131, 155, 173, 193, 244, 273, 277, 328, 333, 360, 382],
        [30, 47, 95, 108, 127, 165, 188, 211, 273, 349, 354, 368, 391],
        [19, 52, 87, 98, 100, 122, 125, 157, 159, 215, 217, 235, 254, 309, 336, 344, 349, 382],
        [19, 85, 87, 136, 144, 180, 190, 229, 310, 345, 365, 376, 390],
        [35, 52, 87, 113, 124, 135, 145, 167, 174, 225, 226, 244, 247, 300, 359],
        [10, 35, 69, 103, 129, 144, 165, 180, 230, 232, 329, 335, 353, 359, 371, 390],
        [5, 13, 80, 83, 135, 139, 142, 176, 179, 190, 205, 217, 282, 298, 308, 334, 353, 359],
        [24, 52, 67, 108, 135, 138, 153, 176, 231, 249, 283, 304, 337, 351, 353, 355],
        [90, 93, 127, 132, 136, 163, 165, 196, 284, 306, 353, 383],
        [20, 37, 103, 126, 135, 184, 204, 215, 221, 288, 300, 329, 339, 358, 383],
        [16, 36, 52, 99, 117, 136, 171, 190, 243, 244, 303, 315, 333, 349, 373, 382],
        [0, 57, 69, 98, 125, 129, 132, 158, 165, 190, 191, 193, 198, 254, 256, 285, 288, 303, 339, 346, 351, 391],
        [1, 13, 21, 87, 125, 132, 150, 204, 240, 249, 253, 265, 288, 334, 343, 348, 349, 359],
        [29, 40, 71, 80, 91, 99, 122, 203, 289, 290, 298, 329, 353, 380, 390],
        [2, 5, 36, 57, 93, 102, 135, 140, 314, 343, 398],
        [20, 59, 107, 193, 204, 246, 247, 336, 341, 342, 354, 359, 360, 383],
        [47, 71, 93, 111, 116, 120, 122, 130, 251, 286, 298, 299, 348],
        [21, 52, 56, 69, 76, 118, 120, 125, 137, 274, 280, 324, 327, 335, 339, 340],
        [23, 29, 57, 75, 98, 132, 149, 157, 160, 235, 244, 288, 327, 340, 354, 372, 377],
        [4, 22, 97, 103, 111, 129, 131, 151, 158, 176, 204, 248, 265, 309, 359, 391, 392],
        [15, 17, 73, 105, 115, 170, 186, 228, 255, 317, 321, 339, 349, 379, 380, 381],
        [17, 52, 72, 103, 188, 329, 342, 353, 358, 359, 374, 376, 380, 393],
        [40, 48, 74, 124, 135, 191, 225, 226, 237, 291, 300, 304, 310, 347, 359, 380, 396],
        [2, 36, 47, 57, 122, 125, 174, 188, 203, 224, 255, 325, 353, 359, 387],
        [13, 58, 69, 83, 115, 120, 134, 161, 165, 174, 175, 191, 246, 255, 280, 353, 357, 358, 359, 379],
        [1, 29, 47, 87, 89, 135, 176, 190, 209, 236, 304, 344, 348, 358, 359, 378],
        [8, 13, 40, 52, 58, 61, 71, 125, 144, 168, 189, 210, 260, 337, 338, 340, 347, 376, 380],
        [29, 90, 126, 127, 129, 136, 145, 159, 165, 188, 274, 284, 288, 316, 329, 358, 380],
        [2, 19, 103, 120, 123, 159, 165, 175, 177, 180, 238, 244, 251, 294, 329, 342, 345, 349, 357, 376, 392],
        [41, 42, 59, 71, 81, 98, 101, 117, 159, 171, 180, 240, 285, 290, 299, 344, 353],
        [83, 103, 108, 142, 175, 248, 290, 300, 321, 354, 365, 374, 382],
        [12, 67, 105, 130, 140, 171, 188, 192, 244, 276, 290, 302, 348, 349, 357, 360, 380],
        [4, 13, 36, 65, 75, 160, 165, 185, 198, 235, 293, 324, 327, 333, 345, 347, 375, 383],
        [37, 61, 80, 125, 234, 283, 290, 353, 359, 378, 383],
        [9, 32, 83, 110, 155, 248, 252, 288, 313],
        [37, 48, 52, 93, 167, 170, 179, 244, 267, 288, 296, 333, 335, 355, 374],
        [35, 92, 98, 153, 165, 184, 215, 233, 242, 290, 339, 355],
        [9, 38, 83, 121, 127, 165, 176, 235, 253, 305, 330, 337, 355, 358, 359],
        [35, 117, 122, 125, 132, 136, 183, 235, 254, 280, 285, 286, 329, 334, 338, 353, 372],
        [6, 87, 117, 125, 141, 144, 153, 157, 179, 215, 267, 272, 289, 329, 336, 359],
        [7, 14, 37, 82, 135, 147, 154, 202, 244, 290, 297, 298, 345, 355, 368, 383],
        [105, 135, 173, 244, 255, 280, 288, 299, 304, 307, 337, 338, 341, 344],
        [19, 31, 33, 77, 92, 99, 114, 151, 173, 202, 253, 318, 329, 333, 358, 371],
        [1, 8, 14, 30, 39, 120, 157, 172, 227, 229, 251, 257, 272, 339, 380],
        [19, 98, 171, 191, 213, 246, 289, 353, 357, 366, 374, 383],
        [8, 98, 125, 126, 144, 152, 244, 277, 282, 290, 322, 393],
        [17, 206, 211, 224, 336, 338, 386],
        [52, 55, 71, 99, 105, 191, 211, 215, 224, 246, 290, 300, 336, 339, 361],
        [15, 16, 44, 66, 96, 121, 127, 162, 167, 202, 219, 243, 244, 254, 282, 320, 345, 390],
        [7, 83, 92, 121, 130, 160, 177, 280, 308, 309, 339, 350, 352, 358, 380, 390],
        [67, 122, 144, 148, 170, 173, 184, 222, 280, 374],
        [2, 4, 15, 19, 115, 130, 136, 148, 172, 180, 243, 251, 313, 329, 333, 359, 364],
        [90, 98, 108, 124, 167, 176, 202, 254, 286, 351, 359],
        [80, 126, 135, 167, 212, 242, 243, 256, 283, 286, 295, 327, 337, 340, 346, 357, 358, 364],
        [19, 108, 125, 132, 149, 172, 180, 186, 200, 254, 286, 296, 339, 344, 350, 359, 391],
        [62, 65, 67, 105, 127, 129, 132, 250, 298, 307, 334, 344, 359, 383],
        [31, 59, 87, 107, 121, 131, 132, 160, 244, 246, 247, 253, 344, 360, 394],
        [4, 39, 76, 125, 130, 148, 168, 170, 191, 196, 298, 306, 327, 338, 345, 349, 360, 375],
        [13, 14, 32, 84, 98, 122, 126, 156, 188, 235, 255, 330, 336, 338, 375, 380, 389],
        [5, 18, 31, 54, 71, 74, 76, 81, 87, 93, 126, 129, 182, 303, 327, 353, 359, 373, 391],
        [13, 37, 64, 137, 138, 180, 244, 247, 251, 253, 269, 284, 308, 344, 374, 376],
        [5, 7, 10, 23, 35, 125, 168, 169, 187, 191, 192, 313, 337, 340, 342, 365],
        [62, 67, 122, 125, 165, 190, 217, 243, 254, 256, 265, 299, 318, 353, 394],
        [4, 24, 62, 92, 109, 118, 134, 143, 144, 176, 190, 199, 221, 299, 349, 380],
        [22, 35, 64, 74, 92, 113, 161, 172, 193, 282, 287, 307, 359, 393],
        [37, 50, 66, 75, 76, 78, 82, 87, 139, 159, 172, 176, 188, 231, 352, 371],
        [19, 31, 75, 121, 144, 152, 163, 171, 172, 198, 243, 246, 285, 288, 289, 333, 344, 347, 357, 398],
        [1, 15, 17, 51, 57, 65, 69, 127, 241, 244, 254, 259, 329, 336, 358],
        [9, 95, 117, 121, 125, 137, 204, 242, 247, 301, 309, 314, 334, 339, 350, 354, 358],
        [9, 61, 96, 111, 130, 163, 180, 211, 225, 226, 241, 253, 282, 283, 346, 355, 359, 380, 383],
        [94, 117, 121, 124, 126, 130, 135, 172, 199, 232, 286, 325, 336, 352, 362, 375],
        [110, 125, 163, 250, 265, 303, 329, 334, 391],
        [47, 72, 76, 111, 125, 157, 169, 245, 254, 285, 287, 297, 298, 336, 353, 359, 383],
        [62, 93, 115, 125, 127, 130, 174, 231, 308, 310, 329, 333, 355, 359, 390],
        [44, 116, 163, 167, 180, 191, 200, 245, 254, 329, 343, 345, 354, 364],
        [31, 62, 105, 108, 144, 145, 162, 173, 177, 191, 198, 247, 249, 344, 345, 348, 353],
        [29, 65, 66, 74, 83, 87, 125, 148, 165, 228, 334, 353, 359, 380, 383, 391],
        [2, 15, 125, 130, 239, 290, 312, 336, 337, 341, 398],
        [40, 76, 87, 114, 119, 120, 165, 229, 265, 313, 324, 349, 358, 383],
        [48, 62, 87, 91, 103, 186, 195, 212, 214, 315, 322, 327, 330, 338, 339],
        [9, 32, 85, 108, 135, 191, 224, 237, 257, 288, 307, 310, 313, 318, 329, 337, 352, 395],
        [87, 93, 102, 112, 129, 154, 171, 236, 317, 320, 349, 350, 359, 380],
        [1, 14, 92, 111, 137, 140, 186, 290, 329, 336, 354, 355, 378, 379, 383],
        [7, 26, 37, 47, 84, 101, 144, 153, 175, 180, 198, 232, 243, 305, 333, 353, 357, 383],
        [20, 58, 76, 93, 99, 127, 134, 154, 188, 206, 246, 312, 313, 324],
        [2, 12, 117, 125, 160, 167, 188, 206, 279, 285, 287, 301, 329, 332, 333, 336, 344, 362],
        [2, 76, 126, 127, 137, 165, 244, 288, 290, 339, 346, 351, 359, 365, 383],
        [66, 108, 136, 151, 174, 265, 344, 351, 353, 357, 378, 386],
        [8, 76, 87, 90, 111, 116, 124, 176, 198, 334, 337, 349, 359, 379, 394],
        [32, 36, 42, 76, 81, 125, 127, 205, 227, 262, 280, 288, 326, 336, 390, 398],
        [9, 32, 65, 83, 89, 93, 97, 122, 129, 178, 180, 215, 241, 246, 323, 332, 353, 362, 364, 380],
        [5, 24, 56, 127, 130, 155, 184, 191, 217, 235, 245, 339, 344, 358, 359, 362, 380],
        [14, 40, 64, 71, 93, 108, 131, 165, 188, 204, 217, 235, 237, 241, 248, 308, 309, 318, 380, 387],
        [17, 29, 34, 74, 125, 175, 184, 196, 211, 275, 301, 318, 327, 334, 349, 355, 358, 368],
        [15, 45, 110, 111, 116, 129, 132, 211, 247, 275, 286, 317, 333, 334, 377, 383],
        [4, 5, 59, 87, 103, 124, 125, 127, 130, 165, 241, 265, 299, 353, 360],
        [31, 120, 124, 135, 154, 197, 235, 243, 247, 248, 258, 309, 320, 335, 357],
        [50, 125, 127, 130, 137, 147, 171, 172, 267, 289, 301, 308, 325, 334, 337, 353, 360, 374, 391],
        [62, 64, 69, 87, 111, 118, 129, 134, 212, 239, 244, 246, 250, 254, 307, 322, 329, 370, 372],
        [54, 92, 128, 160, 198, 244, 248, 255, 284, 314, 335, 349, 358, 360, 376, 380],
        [9, 13, 29, 54, 72, 89, 110, 122, 126, 139, 158, 159, 163, 230, 304, 306, 313],
        [1, 9, 54, 95, 108, 132, 176, 193, 243, 251, 339, 378],
        [0, 96, 99, 135, 137, 184, 212, 232, 251, 315, 334],
        [140, 157, 165, 182, 235, 294, 314, 349, 354, 365],
        [14, 18, 31, 56, 117, 125, 138, 227, 246, 283, 334, 345, 352, 357, 361],
        [0, 71, 82, 130, 131, 144, 161, 235, 247, 301, 333, 335, 345, 353, 355, 359, 360, 374],
        [6, 23, 35, 117, 125, 141, 169, 200, 244, 288, 298, 338, 353, 379],
        [10, 98, 125, 127, 138, 153, 219, 244, 307, 350, 353, 366, 367],
        [9, 32, 40, 122, 126, 127, 170, 176, 300, 334, 350, 391],
        [6, 13, 31, 87, 89, 97, 125, 165, 171, 173, 176, 244, 331, 348, 373],
        [10, 61, 87, 105, 123, 125, 127, 195, 260, 265, 323, 361, 362],
        [2, 20, 90, 124, 353, 354, 378, 382],
        [5, 48, 58, 83, 98, 117, 125, 126, 196, 198],
        [13, 37, 50, 64, 66, 79, 99, 132, 135, 244, 247, 380],
        [57, 165, 235, 238, 248, 272, 287, 299, 327, 329, 334, 350, 353, 380],
        [55, 66, 118, 125, 130, 169, 250, 255, 271, 314, 324, 338, 353],
        [7, 31, 62, 84, 103, 105, 111, 126, 132, 149, 154, 191, 250, 334, 372, 375],
        [56, 81, 114, 117, 120, 124, 127, 128, 154, 254, 290, 317, 345, 354],
        [4, 13, 86, 101, 153, 191, 193, 231, 243, 258, 283, 288, 308, 353, 387, 392],
        [5, 37, 58, 62, 67, 84, 87, 176, 237, 267, 333, 334, 347],
        [1, 7, 74, 110, 165, 168, 182, 233, 288, 305, 309, 315, 347, 351, 353, 358, 360, 375],
        [57, 84, 129, 138, 165, 243, 244, 259, 280, 282, 290, 380, 383]
    ];

    /// <summary>
    /// </summary>
    /// <value>The hashes.</value>
    public static short[][] Hashes
    {
        get => _hashes;
        set => _hashes = value;
    }
}