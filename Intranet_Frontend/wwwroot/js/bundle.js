/*
 * ATTENTION: The "eval" devtool has been used (maybe by default in mode: "development").
 * This devtool is neither made for production nor for readable output files.
 * It uses "eval()" calls to create a separate source file in the browser devtools.
 * If you are trying to read the output file, select a different devtool (https://webpack.js.org/configuration/devtool/)
 * or disable the default devtool with "devtool: false".
 * If you are looking for production-ready output files, see mode: "production" (https://webpack.js.org/configuration/mode/).
 */
/******/ (() => { // webpackBootstrap
/******/ 	var __webpack_modules__ = ({

/***/ "./scripts/app.ts":
/*!************************!*\
  !*** ./scripts/app.ts ***!
  \************************/
/***/ (function() {

eval("var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {\n    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }\n    return new (P || (P = Promise))(function (resolve, reject) {\n        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }\n        function rejected(value) { try { step(generator[\"throw\"](value)); } catch (e) { reject(e); } }\n        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }\n        step((generator = generator.apply(thisArg, _arguments || [])).next());\n    });\n};\ndocument.addEventListener(\"DOMContentLoaded\", () => {\n    const searchInput = document.getElementById(\"input-search\");\n    const button = document.getElementById(\"btn-search\");\n    const resultDiv = document.getElementById(\"result-search\");\n    if (button) {\n        button.addEventListener(\"click\", () => __awaiter(this, void 0, void 0, function* () {\n            try {\n                const searchTerm = searchInput.value.trim();\n                if (searchTerm === \"\" || searchTerm === null) {\n                    alert(\"Bitte Suchfeld füllen!\");\n                    return;\n                }\n                const response = yield fetch(`/Home/GetMatchingElements?searchTerm=${encodeURIComponent(searchTerm)}`);\n                if (response.ok) {\n                    // Display results\n                    resultDiv.removeAttribute(\"hidden\");\n                }\n                else {\n                    alert(\"Ein Fehler ist aufgetreten.\");\n                }\n            }\n            catch (error) {\n                alert(\"Ein Fehler ist aufgetreten.\");\n            }\n        }));\n    }\n});\ndocument.addEventListener(\"DOMContentLoaded\", () => {\n});\n\n\n//# sourceURL=webpack://intranet_frontend/./scripts/app.ts?");

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module is referenced by other modules so it can't be inlined
/******/ 	var __webpack_exports__ = {};
/******/ 	__webpack_modules__["./scripts/app.ts"]();
/******/ 	
/******/ })()
;