/**************************************************************************************

Copyright (C) 2008 Autodesk, Inc. and/or its licensors.
All Rights Reserved.

The coded instructions, statements, computer programs, and/or related material 
(collectively the "Data") in these files contain unpublished information 
proprietary to Autodesk, Inc. and/or its licensors, which is protected by 
Canada and United States of America federal copyright law and by international 
treaties. 

The Data may not be disclosed or distributed to third parties, in whole or in
part, without the prior written consent of Autodesk, Inc. ("Autodesk").

THE DATA IS PROVIDED "AS IS" AND WITHOUT WARRANTY.
ALL WARRANTIES ARE EXPRESSLY EXCLUDED AND DISCLAIMED. AUTODESK MAKES NO
WARRANTY OF ANY KIND WITH RESPECT TO THE DATA, EXPRESS, IMPLIED OR ARISING
BY CUSTOM OR TRADE USAGE, AND DISCLAIMS ANY IMPLIED WARRANTIES OF TITLE, 
NON-INFRINGEMENT, MERCHANTABILITY OR FITNESS FOR A PARTICULAR PURPOSE OR USE. 
WITHOUT LIMITING THE FOREGOING, AUTODESK DOES NOT WARRANT THAT THE OPERATION
OF THE DATA WILL BE UNINTERRUPTED OR ERROR FREE. 

IN NO EVENT SHALL AUTODESK, ITS AFFILIATES, PARENT COMPANIES, LICENSORS
OR SUPPLIERS ("AUTODESK GROUP") BE LIABLE FOR ANY LOSSES, DAMAGES OR EXPENSES
OF ANY KIND (INCLUDING WITHOUT LIMITATION PUNITIVE OR MULTIPLE DAMAGES OR OTHER
SPECIAL, DIRECT, INDIRECT, EXEMPLARY, INCIDENTAL, LOSS OF PROFITS, REVENUE
OR DATA, COST OF COVER OR CONSEQUENTIAL LOSSES OR DAMAGES OF ANY KIND),
HOWEVER CAUSED, AND REGARDLESS OF THE THEORY OF LIABILITY, WHETHER DERIVED
FROM CONTRACT, TORT (INCLUDING, BUT NOT LIMITED TO, NEGLIGENCE), OR OTHERWISE,
ARISING OUT OF OR RELATING TO THE DATA OR ITS USE OR ANY OTHER PERFORMANCE,
WHETHER OR NOT AUTODESK HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH LOSS
OR DAMAGE. 

**************************************************************************************/
#ifndef _KFBX_RENAMING_STRATEGY_FBX6_H_
#define _KFBX_RENAMING_STRATEGY_FBX6_H_

#include <fbxfilesdk/kfbxplugins/kfbxrenamingstrategybase.h>
#include <fbxfilesdk/kfbxplugins/kfbxrenamingstrategyutilities.h>
#include <fbxfilesdk/kfbxplugins/kfbxscene.h>
#include <fbxfilesdk/components/kbaselib/klib/kname.h>

#include <fbxfilesdk/fbxfilesdk_nsbegin.h>
class KFBX_DLL KFbxRenamingStrategyFbx6: public KFbxRenamingStrategyBase
{
public:
    
    KFbxRenamingStrategyFbx6();
    virtual ~KFbxRenamingStrategyFbx6();

    virtual bool DecodeScene(KFbxScene* pScene);
    virtual bool EncodeScene(KFbxScene* pScene);
    virtual bool DecodeString(KName& pName);
    virtual bool EncodeString(KName& pName);
    virtual void CleanUp();
};


#include <fbxfilesdk/fbxfilesdk_nsend.h>
#endif
