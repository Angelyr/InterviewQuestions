public class CSProblems{
    
    public int Tribonacci(int n) {
        int t0 = 0;
        int t1 = 1;
        int t2 = 1;
        
        if(n==0) return 0;
        if(n==1 || n==2) return 1;
        
        int t = 3;
        for(int i=3; i <= n; i++){
            t = t0 + t1 + t2;
            t0 = t1;
            t1 = t2;
            t2 = t;
        }
        
        return t;
    }

    public int[] DistributeCandies(int candies, int num_people) {
        int[] result = new int[num_people];
        
        int i=0;
        int myCandies = 1;
        while(candies > 0){
            if(myCandies > candies){
                result[i] += candies;
                break;
            }
            else{
            result[i] += myCandies;
            candies -= myCandies;    
            }
            
            
            myCandies+=1;
            i+=1;
            if(i == num_people) i = 0;
        }
        return result;
    }



    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }


    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if(root.val < val){
            if(root.right == null){
                root.right = new TreeNode(val);
                return root;
            }
            else{
                root.right = InsertIntoBST(root.right, val);
                return root;
            }
        }
        
        if(root.val > val){
            if(root.left == null){
                root.left = new TreeNode(val);
                return root;
            }
            else{
                root.left = InsertIntoBST(root.left, val);
                return root;
            }
        }
        
        return null;
    }

    public string ToLowerCase(string str) {
        return str.ToLower();
    }

    public IList<string> FindAndReplacePattern(string[] words, string pattern) {
        List<string> output = new List<string>();
        foreach(string word in words)
        {
            Dictionary<char, char> perm = new Dictionary<char, char>();
            bool matching = true;
            
            for(int i=0; i < pattern.Length; i++)
            {
                char letter = word[i];
                char match = pattern[i];
            
                if(perm.ContainsKey(match))
                {
                    if(perm[match] == letter) continue;
                    else matching = false;
                }
                else if(perm.ContainsValue(letter))
                {
                    matching = false;
                }
                else
                {
                    perm[match] = letter;
                }
            }
            
            if(matching) output.Add(word);
            
        }
        return output;
    }

    public string GetExpr(string expression)
    {
        return expression.Substring(2,expression.Length-3);
    }
    
    public List<string> GetAllExpr(string expression)
    {
        List<string> result = new List<string>();
        int left = 0;
        int right = 0;
        string expr = "";
        foreach(char c in expression.Substring(2, expression.Length-2))
        {
            if(c == '(') left+=1;
            if(c == ')') right +=1;
            
            
            if(c == ',' && left == right)
            {
                result.Add(expr);
                expr = "";
                left = 0;
                right = 0;
                continue;
            }
            if(right > left) result.Add(expr);
            
            expr += c;
        }
        return result;
    }
    
    public bool ParseBoolExpr(string expression) 
    {
        if(expression == "t") return true;
        if(expression == "f") return false;
        
        if(expression[0] == '!') return !ParseBoolExpr(GetExpr(expression));
        
        bool result = ParseBoolExpr(GetAllExpr(expression)[0]);
        
        if(expression[0] == '&')
        {
            foreach(string expr in GetAllExpr(expression))
            {
                result = result & ParseBoolExpr(expr);
            }
        }
        
        if(expression[0] == '|')
        {
            foreach(string expr in GetAllExpr(expression))
            {
                result = result | ParseBoolExpr(expr);
            }
        }
        
        return result;
    }
}